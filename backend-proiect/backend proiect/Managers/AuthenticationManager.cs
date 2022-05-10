using backend_proiect.Entities;
using backend_proiect.Models;
using Microsoft.AspNetCore.Identity;

namespace backend_proiect.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ITokenManager tokenManager;

        public AuthenticationManager(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            ITokenManager tokenManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenManager = tokenManager;
        }

        public async Task Signup(VisitorModel signupUserModel)
        {
            var user = new IdentityUser
            {
                Email = signupUserModel.Email,
                UserName = signupUserModel.Email
            };

            var result = await userManager.CreateAsync(user, signupUserModel.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, signupUserModel.Role);
            }
        }

        public async Task<TokenModel> Login(VisitorModel loginUserModel)
        {
            var user = await userManager.FindByEmailAsync(loginUserModel.Email);
            if(user != null)
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, loginUserModel.Password, false);
                if(result.Succeeded)
                {
                    //Create token
                    var token = await tokenManager.CreateToken(user); //new manager responsible with creating the token

                    return new TokenModel { Token = token };
                }
            }

            return null;
        }
    }
}
