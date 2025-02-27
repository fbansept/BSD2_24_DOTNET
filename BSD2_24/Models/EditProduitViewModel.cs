using Microsoft.AspNetCore.Mvc.Rendering;

namespace BSD2_24.Models
{
    public class EditProduitViewModel
    {
        public Produit Produit { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}
