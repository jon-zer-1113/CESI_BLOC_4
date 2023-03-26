using System.ComponentModel.DataAnnotations.Schema;

namespace B4_API.Models
{
    public class CommandeFournisseur
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public DateTimeOffset DateHeure { get; set; }
        public float Prix { get; set; }
        public int Quantite { get; set; }
        [ForeignKey("ProduitId")]
        public int ProduitId { get; set; }
        public Produit Produit { get; set; }
    }
}
