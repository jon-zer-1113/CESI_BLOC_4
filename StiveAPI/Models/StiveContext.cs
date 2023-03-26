using Microsoft.EntityFrameworkCore;

namespace StiveAPI.Models
{
    public class StiveContext : DbContext
    {
        public StiveContext(DbContextOptions<StiveContext> options) 
            :base(options) 
        {
        }
        public DbSet<User> Users { get; set; } = null!;
    }
    // "StiveContext" hérite de "DbContext" (qui est une classe de base fournie par le package "Microsoft.EntityFrameworkCore" qui gère la communication entre une application et une base de données.)
    // Puis je définis un constructeur de la classe "StiveContext" avec des arguments et des options qui permettent la communication avec la base de données.
    // Enfin, la classe définit une propriété "Users" qui est utilisé pour interagir avec les données de l'utilisateur dans la base de données. La propriété n'a pas de valeur par défaut et doit être défini dans le code qui l'utilise.
}
