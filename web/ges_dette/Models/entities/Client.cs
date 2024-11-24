using System.ComponentModel.DataAnnotations;

namespace ges_dette.Models.entities
{
    public class Client
    {
        public ICollection<Dette>? Dettes { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
        public int Id { get; set; }

        [MaxLength(255)] // Limiter la longueur à 255 caractères
        public string? Surnom { get; set; }

        [MaxLength(20)] // Limiter la longueur à 20 caractères
        public string? Telephone { get; set; }

        [MaxLength(500)] // Limiter la longueur à 500 caractères
        public string? Adresse { get; set; }
    }


}