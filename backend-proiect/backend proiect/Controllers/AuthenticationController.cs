using backend_proiect.Managers;
using backend_proiect.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationManager authenticationManager;

        public AuthenticationController(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] VisitorModel model)
        {
            try
            {
                await authenticationManager.Signup(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Something failed");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] VisitorModel model)
        {
            try
            {
                var tokens = await authenticationManager.Login(model);

                if (tokens != null)
                    return Ok(tokens);
                else
                {
                    return BadRequest("Something failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }
    }
}
