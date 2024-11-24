using ges_dette.Models.entities;
using Microsoft.EntityFrameworkCore;
namespace ges_dette{

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
    options.UseMySql("Server=localhost;Database=ges_dette,3306;User=root;Password=;", serverVersion);
}


     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    // Configurer la relation entre Client et Dette
         modelBuilder.Entity<Client>()
        .HasMany(c => c.Dettes)
        .WithOne(d => d.Client)
        .HasForeignKey(d => d.ClientId); 
    }
}
}