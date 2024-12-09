namespace Cours.Models;
public class Course
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan HeureDebut { get; set; }
    public TimeSpan HeureFin { get; set; }
    public int NombreHeures { get; set; }
    public string Semestre { get; set; }

    public int ProfessorId { get; set; }
     public Professor professeur{ get; set; }


    public int ModuleId { get; set; }
    public Module Module { get; set; }

       public ICollection<Absence> Absences { get; set; }
}
