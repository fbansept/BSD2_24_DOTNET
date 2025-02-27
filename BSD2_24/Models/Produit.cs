using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD2_24.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateDeSortie { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal Prix { get; set; }
    }
}
