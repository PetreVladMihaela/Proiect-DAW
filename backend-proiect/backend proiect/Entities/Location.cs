using System.ComponentModel.DataAnnotations;

namespace backend_proiect.Entities
{
    public class Location
    {
        [Required, Key]
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }

        [Required]
        public int LandmarkId { get; set; }
        public virtual Landmark Landmark { get; set; } = null!;
    }
}
