using UnderAPILogin.Models;

namespace UnderAPILogin.Repositories
{
    public interface IDeleteUserRepository
    {
        User DeleteUser(User user);
    }
}