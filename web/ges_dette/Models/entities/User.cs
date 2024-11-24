using System.ComponentModel.DataAnnotations;

namespace ges_dette.Models.entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(255)] // Limiter la longueur à 255 caractères pour la colonne 'Surnom'
        public string? Surnom { get; set; }

        [MaxLength(20)] // Limiter la longueur à 20 caractères pour le numéro de téléphone
        public string? Telephone { get; set; }

        [MaxLength(500)] // Limiter la longueur à 500 caractères pour l'adresse
        public string? Adresse { get; set; }

        public Client? Client { get; set; }
    }
}
