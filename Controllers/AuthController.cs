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
    private readonly IDeleteUserService _deleteUserService;
    private readonly IInsertMusicService _insertMusicService;

    public AuthController(IAuthService authService, IRegisterUserService registerUserService, IDeleteUserService deleteUserService, IInsertMusicService insertMusicService)
    {
        _authService = authService;
        _registerUserService = registerUserService;
        _deleteUserService = deleteUserService;
        _insertMusicService = insertMusicService;
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
            return BadRequest(new { message = ex.Message });
        }
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

            return Ok(new { message = "Login bem-sucedido" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Erro ao processar a solicitação: {ex.Message}" });
        }
    }

    [HttpDelete("Delete")]
    public IActionResult Delete([FromBody] User user)
    {
        try
        {
            User userDeleted = _deleteUserService.DeleteUser(user);

            return Ok(new { message = $"Usuário '{userDeleted.Email}' removido com sucesso." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("InsertMusic")]
    public IActionResult InsertMusic([FromBody] Music music)
    {
        try
        {
            _insertMusicService.InsertMusic(music);

            return Ok(new { message = $"Música inserida com sucesso." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}