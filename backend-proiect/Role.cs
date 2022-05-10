using Microsoft.AspNetCore.Identity;

namespace backend_proiect.Entities
{
    public class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
