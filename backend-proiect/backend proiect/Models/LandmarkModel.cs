using System.ComponentModel.DataAnnotations;

namespace backend_proiect.Models
{
    public class LandmarkModel
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}
