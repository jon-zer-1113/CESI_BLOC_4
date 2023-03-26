namespace B4_API.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CodeClient { get; set; }
        public DateTimeOffset DateInscription { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public int Telephone { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        public string Adresse { get; set; }
    }
}