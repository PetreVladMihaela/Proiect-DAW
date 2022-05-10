using System.ComponentModel.DataAnnotations;

namespace backend_proiect.Entities
{
    public class Landmark
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; } = null!;
        //public string City { get; set; } = null!;
        public virtual Location Location { get; set; } = null!;

        public virtual ICollection<LandmarkVisitor>? LandmarkVisitors { get; set; }
    }
}
