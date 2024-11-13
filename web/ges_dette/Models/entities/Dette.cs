namespace Cours.Models{
    public class Dette{

        public int Id { get; set; }
        public Client client { get; set; }
        public double Montant { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        private static int count;
        public Dette(){count++; Id = count;}
        public override string ToString() {
            return $"Dette [id={Id},  montant={Montant}, date={Date}]";
        }
    }
}