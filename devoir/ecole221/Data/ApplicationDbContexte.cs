using Cours.Models;
using Microsoft.EntityFrameworkCore;

namespace Cours.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
   


  
    modelBuilder.Entity<Absence>()
        .HasOne(a => a.Course)
        .WithMany(c => c.Absences)
        .HasForeignKey(a => a.CourseId);


    modelBuilder.Entity<Absence>()
        .HasOne(a => a.Student)
        .WithMany(s => s.Absences)
        .HasForeignKey(a => a.StudentId);

    modelBuilder.Entity<Course>()
        .HasOne(c => c.professeur)
        .WithMany(p => p.Courses)
        .HasForeignKey(c => c.ProfessorId)
        .OnDelete(DeleteBehavior.Restrict);

   
    modelBuilder.Entity<Course>()
        .HasOne(c => c.Module)
        .WithMany(m => m.Courses)
        .HasForeignKey(c => c.ModuleId)
        .OnDelete(DeleteBehavior.Restrict);
         
    }
   
    public DbSet<Student> Etudiants { get; set; }
    public DbSet<Course> Cours { get; set; }
    public DbSet<Absence> Abscences { get; set; }
    public DbSet<Professor> Professeurs { get; set; }
    public DbSet<Module> Modules { get; set; }

    


}