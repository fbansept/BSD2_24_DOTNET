using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BSD2_24.Data;
using BSD2_24.Models;

namespace BSD2_24.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly BSD2_24Context _context;

        public ProduitsController(BSD2_24Context context)
        {
            _context = context;
        }

        // GET: Produits
        public async Task<IActionResult> Index(string StatusSelectionne, string recherche)
        {

            var requeteProduits = _context.Produit
                    .Include(p => p.Categorie)
                    .AsQueryable();

            IQueryable<string> requeteStatus = from p in _context.Produit
                                            orderby p.Status
                                            select p.Status;

            if (!String.IsNullOrEmpty(recherche))
            {
                requeteProduits = requeteProduits
                    .Where(p => p.Nom!.ToUpper().Contains(recherche.ToUpper()));
            }

            if (!String.IsNullOrEmpty(StatusSelectionne))
            {
                requeteProduits = requeteProduits
                    .Where(p => p.Status!.ToUpper().Equals(StatusSelectionne.ToUpper()));
            }

            ProduitViewModel viewModel = new ProduitViewModel()
            {
                Recherche = recherche,
                Produits = await requeteProduits.ToListAsync(),
                Status = new SelectList(await requeteStatus.Distinct().ToListAsync())
            };

            return View(viewModel);
        }

        // GET: Produits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produit = await _context.Produit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // GET: Produits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,DateDeSortie,Prix,CategorieId")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        // GET: Produits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produit = await _context.Produit.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }

            var categories = _context.Categorie.ToList();

            var categorieSelectList = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nom
            }).ToList();

            return View(new EditProduitViewModel()
            {
                Produit = produit,
                Categories = categorieSelectList
            });
        }

        // POST: Produits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,DateDeSortie,Prix,CategorieId")] Produit produit)
        {
            if (id != produit.Id)
            {
                return NotFound();
            }

            var categories = _context.Categorie.ToList();

            if (ModelState.IsValid)
            {
                try
                {
                    produit.Status = "FIXME";
                    produit.Categorie = categories.Find(c => c.Id == produit.CategorieId);
                    _context.Update(produit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduitExists(produit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var categorieSelectList = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nom
            }).ToList();

            return View(new EditProduitViewModel()
            {
                Produit = produit,
                Categories = categorieSelectList
            });
        }

        // GET: Produits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produit = await _context.Produit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produit = await _context.Produit.FindAsync(id);
            if (produit != null)
            {
                _context.Produit.Remove(produit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduitExists(int id)
        {
            return _context.Produit.Any(e => e.Id == id);
        }
    }
}
