namespace B4_API.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<Utilisateur> Utilisateur { get; set; }
    }
}
