using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using UnderAPILogin.Models;
using UnderAPILogin.Services;

[ApiController]
[Route("")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IAuthService _authService;
    private readonly IRegisterUserService _registerUserService;
    private readonly IDeleteUserService _deleteUserService;
    private readonly IInsertMusicService _insertMusicService;

    public AuthController(ITokenService tokenService, IAuthService authService, IRegisterUserService registerUserService, IDeleteUserService deleteUserService, IInsertMusicService insertMusicService)
    {
        _tokenService = tokenService;
        _authService = authService;
        _registerUserService = registerUserService;
        _deleteUserService = deleteUserService;
        _insertMusicService = insertMusicService;
    }

    [Authorize]
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
            var token = _tokenService.GenerateToken(loginRequest.Email);

            if (user == null || token == null)
            {
                return Unauthorized(new { message = "Email ou senha inválidos." });
            }

            return Ok(new { message = "Login bem-sucedido", token = token});
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Erro ao processar a solicitação: {ex.Message}" });
        }
    }

    [Authorize]
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

    [Authorize]
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