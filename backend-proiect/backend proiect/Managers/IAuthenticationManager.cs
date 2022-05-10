using backend_proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_proiect.Managers
{
    public interface IAuthenticationManager
    {
        Task Signup(VisitorModel signupUserModel);
        Task<TokenModel> Login(VisitorModel loginUserModel);
    }
}
