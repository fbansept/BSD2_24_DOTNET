using BSD2_24.Data;
using BSD2_24.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BSD2_24.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BSD2_24Context _context;

        private string SessionUserName = "SessionUserName";
        private string SessionUserId = "SessionUserId";

        public HomeController(ILogger<HomeController> logger, BSD2_24Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            //HttpContext.Session.SetString(SessionUserName, "a@a.com");
           // HttpContext.Session.SetInt32(SessionUserId, 42);

            return View();
        }

        public IActionResult Privacy()
        {
           // HttpContext.Session.GetString(SessionUserName);

            return View();
        }

        public IActionResult Signin()
        {
            return View(new Utilisateur());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signin([Bind("Email,Password")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilisateur);
        }

        public IActionResult Login()
        {
            return View(new Utilisateur());
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {

                if (utilisateur.Email == null || utilisateur.Password == null)
                {
                    return NotFound();
                }

                var utilisateurBdd = await _context.Utilisateur
                    .FirstOrDefaultAsync(u => u.Email == utilisateur.Email && u.Password == utilisateur.Password);

                if (utilisateurBdd == null)
                {
                    return NotFound();
                }

                HttpContext.Session.SetString(SessionUserName, utilisateur.Email);

                return RedirectToAction(nameof(Index));
            }
            return View(utilisateur);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
