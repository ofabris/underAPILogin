using UnderAPILogin.Models;
using UnderAPILogin.Repositories;
using UnderAPILogin.Services;
using UnderAPILogin.Controllers;

namespace UnderAPILogin.Repositories
{
    public class RegisterUserRepository : IRegisterUserRepository
    {
        private List<User> _users = new List<User>();

        public void AddUser(User user)
        {
            _users.Add(user);
        }
    }
}