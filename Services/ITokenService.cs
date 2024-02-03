using System.Security.Claims;

public interface ITokenService
{
    string GenerateToken(string email);
    ClaimsPrincipal GetPrincipalFromToken(string token);
}