using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using UnderAPILogin.Services;

namespace UnderAPILogin.Controllers
{
    [ApiController]
    [Route("")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            // Implemente a lógica para autenticação usando o serviço de autenticação.
            // Lembre-se de lidar com erros, retornando códigos de status apropriados.

            var user = _authService.Authenticate(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Email ou senha inválidos." });
            }

            // Implemente a geração de tokens JWT ou outra forma de autenticação.

            return Ok(new { message = "Login bem-sucedido", user });
        }
    }

}
