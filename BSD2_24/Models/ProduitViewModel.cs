using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.CodeAnalysis;

namespace BSD2_24.Models
{
    public class ProduitViewModel
    {
        public List<Produit>? Produits { get; set; }
        public string? Recherche { get; set; }

        public SelectList Status { get; set; }

        public string? StatusSelectionne { get; set; }

        public SelectList Categories { get; set; }
    }
}
