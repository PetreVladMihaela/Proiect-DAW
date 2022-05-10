using System.ComponentModel.DataAnnotations;

namespace backend_proiect.Entities
{
    public class Country
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Landmark>? Landmarks { get; set; }
    }
}
