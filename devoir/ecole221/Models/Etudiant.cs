namespace Cours.Models;
public class Student
{
    public int Id { get; set; }
    public string Matricule { get; set; }
    public string NomComplet { get; set; }
    public string Adresse { get; set; }
    public ICollection<Absence> Absences { get; set; }
}
