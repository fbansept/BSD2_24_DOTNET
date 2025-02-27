using Microsoft.AspNetCore.Mvc.Rendering;

namespace BSD2_24.Models
{
    public class ProduitViewModel
    {
        public List<Produit>? Produits { get; set; }
        public string? Recherche { get; set; }

        public SelectList Status { get; set; }

        public string? StatusSelectionne { get; set; }
    }
}
