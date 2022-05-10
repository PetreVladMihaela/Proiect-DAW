using System.ComponentModel.DataAnnotations;

namespace backend_proiect.Models
{
    public class LocationModel
    {
        [Required, Key]
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        [Required]
        public int LandmarkId { get; set; }
    }
}
