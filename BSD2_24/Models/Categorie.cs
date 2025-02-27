using Microsoft.Extensions.Hosting;

namespace BSD2_24.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<Produit> Produits { get; } = new List<Produit>();

    }
}
