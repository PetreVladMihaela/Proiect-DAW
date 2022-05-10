using System.ComponentModel.DataAnnotations;

namespace backend_proiect.Models
{
    public class VisitorModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required, Key]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;

        public string Role { get; set; }

    }
}
