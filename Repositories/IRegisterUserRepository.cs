using UnderAPILogin.Models;

namespace UnderAPILogin.Repositories
{
    public interface IRegisterUserRepository
    {
        void AddUser(User user);
        bool CheckUserExists(string email);
    }
}