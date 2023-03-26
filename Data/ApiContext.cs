using B4_API.Models;
using Microsoft.EntityFrameworkCore;

namespace B4_API.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
        {
        }

        public DbSet<Client> Client { get; set; } = null!;
        public DbSet<CommandeClient> CommandeClient { get; set; } = null!;
        public DbSet<CommandeFournisseur> CommandeFournisseur { get; set; } = null!;
        public DbSet<DetailCommande> DetailCommande { get; set; } = null!;
        public DbSet<Fournisseur> Fournisseur { get; set; } = null!;
        public DbSet<Produit> Produit { get; set; } = null!;
        public DbSet<Role> Role { get; set; } = null!;
        public DbSet<Utilisateur> Utilisateur { get; set; } = null!;
    }
}

// "ApiContext" hérite de "DbContext" (qui est une classe de base fournie par le package "Microsoft.EntityFrameworkCore" qui gère la communication entre une application et une base de données.)
    // Puis je définis un constructeur de la classe "StiveContext" avec des arguments et des options qui permettent la communication avec la base de données.
    // Enfin, je définis les classes, qui sont utilisées pour interagir avec les données dans la base de données. La propriété n'a pas de valeur par défaut et doit être défini dans le code qui l'utilise.