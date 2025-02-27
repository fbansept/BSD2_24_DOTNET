using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace BSD2_24.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public string Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateDeSortie { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal Prix { get; set; }

        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; } = null!; 

    }
}
