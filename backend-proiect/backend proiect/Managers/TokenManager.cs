using backend_proiect.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace backend_proiect.Managers
{
    public class TokenManager : ITokenManager
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<IdentityUser> userManager;

        public TokenManager(IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<string> CreateToken(IdentityUser user)
        {
            var secretKey = configuration.GetSection("Jwt").GetSection("SecretKey").Get<string>();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            //algorithms for cryptography that use the same cryptographic keys for both the encryption of plaintext
            //and the decryption of ciphertext
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>();
            var roles = await userManager.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
