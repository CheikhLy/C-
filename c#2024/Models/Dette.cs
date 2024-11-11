namespace Cours.Models{
    public class Dette{

        public int Id { get; set; }
        public Client client { get; set; }
        public double Montant { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        private static int count;
        public Dette(){count++; Id = count;}

        // public int Id { get => id; set => id = value; }
        // public Client Client { get => client; set => client = value; }
        // public double Montant { get => montant; set => montant = value; }
        // public DateTime Date { get => date; set => date = value; }
        public override string ToString() {
            return $"Dette [id={Id},  montant={Montant}, date={Date}]";
        }
    }
}