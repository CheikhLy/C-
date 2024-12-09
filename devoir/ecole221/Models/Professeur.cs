namespace Cours.Models
{
   public class Professor
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Specialite { get; set; }
    public string Grade { get; set; }

    // Relation avec les cours
    public ICollection<Course> Courses { get; set; }
}

}