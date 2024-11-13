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
        base.OnModelCreating(modelBuilder);
        // Configuration supplémentaire si nécessaire
    }
}
