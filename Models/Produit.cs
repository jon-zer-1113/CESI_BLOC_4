using System.ComponentModel.DataAnnotations.Schema;

namespace B4_API.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Reference { get; set; }
        public string Famille { get; set; }
        public int? Annee { get; set; }
        public float ContenanceEnLitre { get; set; }
        public int Quantite { get; set; }
        public float PrixTtc { get; set; }
        public float PrixHt { get; set; }
        [ForeignKey("FournisseurId")]
        public int FournisseurId { get; set; }
        public Fournisseur Fournisseur { get; set; }
    }
}
