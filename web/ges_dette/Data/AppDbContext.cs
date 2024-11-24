using ges_dette.Models.entities;
using Microsoft.EntityFrameworkCore;

namespace ges_dette.Data
{
    public class AppDbContext : DbContext  // Correction du constructeur
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } // Constructeur ajouté
        
        public DbSet<Client> Client { get; set; }
        public DbSet<Dette> Dette { get; set; }
        public DbSet<User> User { get; set; }
    }
}
