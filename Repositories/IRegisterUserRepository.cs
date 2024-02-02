using UnderAPILogin.Models;

namespace UnderAPILogin.Repositories
{
    public interface IRegisterUserRepository
    {
        void AddUser(User user);

        bool ValidEmail(string email);
        bool CheckUserExists(string email);
    }
}