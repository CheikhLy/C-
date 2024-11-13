namespace Cours.Models{
 public class Client
    {
        
         public ICollection<Dette> Dettes { get; set; }
       
        public User User { get; set; }
         public int UserId { get; set; }
        public int Id { get ; set; }
        public string Surnom { get ; set ; }
        public string Telephone { get; set; }
        public string Adresse { get ; set ; }

      
       

    }
}