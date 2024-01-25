using UnderAPILogin.Models;

namespace UnderAPILogin.Services
{
    public interface IAuthService
    {
        User Authenticate(string Email, string Password);
    }

}
