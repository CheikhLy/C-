using Cours.Models;
using Microsoft.EntityFrameworkCore;

namespace Cours.Core
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Dette> Dette { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=gestion_dette;User ID=root;Password=;",
                                    new MySqlServerVersion(new Version(8, 0, 21))); 
        }
    }
}
