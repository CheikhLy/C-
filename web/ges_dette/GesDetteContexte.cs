using Cours.Models;
using Microsoft.EntityFrameworkCore;

public class GesDetteContexte : DbContext
{
    public GesDetteContexte(DbContextOptions<GesDetteContexte> options)
        : base(options)
    {
    }

    public DbSet<Client> Client { get; set; }
    public DbSet<User> User{get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder options) {
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 21)); 
    options.UseMySql("Host=localhost;Database=gestion_dette;Username=root;Password=;port=3306", serverVersion);
}


     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasIndex(c => c.Telephone).IsUnique();
        modelBuilder.Entity<Client>().HasIndex(c => c.Surnom).IsUnique();
                modelBuilder.Entity<Client>().HasIndex(c => c.Adresse).IsUnique();

        modelBuilder.Entity<Client>().HasIndex(c => new { c.Telephone, c.Surnom ,c.Adresse}).IsUnique();

        // Seed data
        modelBuilder.Entity<Client>().HasData(
            new Client { Id = 1, Surnom = "John",  Adresse = "Doe", Telephone = "123456789" },
            new Client { Id = 2, Surnom = "Jane", Adresse = "Smith", Telephone = "987654321" }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "admin", Password = "admin123" },
            new User { Id = 2, Username = "user1", Password = "password1" }
        );

        modelBuilder.Entity<Dette>().HasData(
            new Dette { Id = 1, Montant = 100.50m, Date = DateTime.Now.AddDays(30), Id = 1 },
            new Dette { Id = 2, Montant = 250.00m, Date = DateTime.Now.AddDays(60), Id = 2 }
        );
    }
}
