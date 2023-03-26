using System.ComponentModel.DataAnnotations.Schema;

namespace B4_API.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CodeUtilisateur { get; set; }
        public DateTimeOffset DateInscription { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public int Telephone { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        public string Adresse { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}

// Recommandé d'utiliser "DateTimeOffset" pour éviter les problèmes de conversion et d'affichage incorrects des dates et heures (dans plusieurs fuseaux horaires).