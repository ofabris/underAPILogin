using UnderAPILogin.Models;

namespace UnderAPILogin.Repositories
{
    public interface IUserRepository
    {
        User GetUserByEmailAndPassword(string Email, string Password);
    }
}