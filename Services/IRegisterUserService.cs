using UnderAPILogin.Models;
using UnderAPILogin.Repositories;
using UnderAPILogin.Services;
using UnderAPILogin.Controllers;

namespace UnderAPILogin.Services
{
    public interface IRegisterUserService
    {
        void AddUser(User user);
    }
}