namespace Cours.Models{
 public class User
    {
        private int id;
        private String login;
        private String password;
        private String nom;
         private String prenom;

        private static int count;
        
        private Client client;
        

        public User()
        {
            count++;
            id = count;
        }
       
        // public int Id { get => id; set => id = value; }
        // public string Surnom { get => surnom; set => surnom = value; }
        // public string Telephone { get => telephone; set => telephone = value; }
        // public string Adresse { get => adresse; set => adresse = value; }

      
        public override string ToString()
        {
            return "User[" +
                    "id=" + id +
                    ", login='" + login + '\'' +
                    ", password='" + password + '\'' +
                    ", nom='" + nom + '\''+
                    ", prenom='"+prenom+ ']';
                    ;

        }

     

    }
}