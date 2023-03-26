using System.ComponentModel.DataAnnotations.Schema;

namespace B4_API.Models
{
    public class DetailCommande
    {
        public int Id { get; set; }
        public int ProduitId { get; set; }
        public Produit Produit { get; set; }
        public int CommandeFournisseurId { get; set; }
        public CommandeFournisseur CommandeFournisseur { get; set; }
        public int CommandeClientId { get; set; }
        public CommandeClient CommandeClient { get; set; }
        public int Quantite { get; set; }
    }
}
