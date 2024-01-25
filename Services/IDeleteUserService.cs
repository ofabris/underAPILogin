using UnderAPILogin.Models;

namespace UnderAPILogin.Services
{
    public interface IDeleteUserService
    {
        User DeleteUser(User user);
    }
}