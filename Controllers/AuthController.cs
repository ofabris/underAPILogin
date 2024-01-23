using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using UnderAPILogin.Models;
using UnderAPILogin.Services;

[ApiController]
[Route("")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IRegisterUserService _registerUserService;

    public AuthController(IAuthService authService, IRegisterUserService registerUserService)
    {
        _authService = authService;
        _registerUserService = registerUserService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            var user = _authService.Authenticate(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Email ou senha inválidos." });
            }

            // Implemente a geração de tokens JWT ou outra forma de autenticação.

            return Ok(new { message = "Login bem-sucedido" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Erro ao processar a solicitação: {ex.Message}" });
        }
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] User user)
    {
        try
        {
            _registerUserService.AddUser(user);
            return Ok(new { message = "Usuário registrado com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message});
        }
    }
}