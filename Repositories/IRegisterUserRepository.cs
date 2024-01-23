using UnderAPILogin.Models;

namespace UnderAPILogin.Repositories
{
    public interface IRegisterUserRepository
    {
        void AddUser(User user);
        void CheckUserExists(string email);
        bool ValidNull<T>(T obj);
    }

}