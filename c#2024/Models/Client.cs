namespace Cours.Models{
 public class Client
    {
        private int id;
        private String surnom;
        private String telephone;
        private String adresse;
        private static int count;
        private List<Dette> dettes;
        public List<Dette> Dettes { get;  }= new List<Dette>();
        public void AddDette(Dette dette)
        {
            Dettes.Add(dette);
            dette.client = this;
        }

        public Client()
        {
            count++;
            id = count;
        }
       
        public int Id { get => id; set => id = value; }
        public string Surnom { get => surnom; set => surnom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Adresse { get => adresse; set => adresse = value; }

      
        public override string ToString()
        {
            return "Client[" +
                    "id=" + id +
                    ", surnom='" + surnom + '\'' +
                    ", telephone='" + telephone + '\'' +
                    ", adresse='" + adresse + ']';

        }

        public bool equals(Client other)
        {
            if (this == other) return true;
            if (other == null) return false;
            Client client = (Client)other;
            return id == client.id &&
                    Object.Equals(surnom, client.surnom) &&
                    Object.Equals(telephone, client.telephone) &&
                    Object.Equals(adresse, client.adresse);

        }

    }
}