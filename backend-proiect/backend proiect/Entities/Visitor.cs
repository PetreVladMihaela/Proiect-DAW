
using System.ComponentModel.DataAnnotations;

namespace backend_proiect.Entities
{
    public class Visitor
    {
        //[Required, Key]
        //public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required, Key]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;

        public virtual ICollection<LandmarkVisitor> LandmarkVisitors { get; set; }

        public string Role { get; set; }

    }
}
