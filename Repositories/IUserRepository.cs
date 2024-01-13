using UnderAPILogin.Models;

namespace UnderAPILogin.Repositories
{
    public interface IUserRepository
    {
        User GetUserByUsernameAndPassword(string username, string password);
    }
}
