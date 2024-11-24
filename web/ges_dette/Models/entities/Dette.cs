namespace ges_dette.Models.entities
{
    public class Dette
    {
        public int Id { get; set; }
        public double? Montant { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int? ClientId { get; set; }
        public Client? Client { get; set; }
    }

}