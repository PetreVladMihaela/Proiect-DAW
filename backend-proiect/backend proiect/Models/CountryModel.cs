using System.ComponentModel.DataAnnotations;

namespace backend_proiect.Models
{
    public class CountryModel
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;
    }
}
