using backend_proiect.Entities;
using Microsoft.AspNetCore.Identity;

namespace backend_proiect.Managers
{
    public interface ITokenManager
    {
        Task<string> CreateToken(IdentityUser user);
    }
}
