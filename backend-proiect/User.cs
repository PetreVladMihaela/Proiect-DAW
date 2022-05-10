using Microsoft.AspNetCore.Identity;

namespace backend_proiect.Entities
{
    public class User : IdentityUser
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
