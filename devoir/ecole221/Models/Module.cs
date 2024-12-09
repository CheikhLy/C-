namespace Cours.Models;
public class Module
{
    public int Id { get; set; }
    public string Libelle { get; set; }
    public ICollection<Course> Courses { get; set; }
}
