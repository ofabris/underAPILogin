using UnderAPILogin.Models;
using UnderAPILogin.Repositories;
using UnderAPILogin.Services;
using UnderAPILogin.Controllers;

namespace UnderAPILogin.Repositories
{
    public interface IRegisterUserRepository
    {
        void AddUser(User user);
    }
}