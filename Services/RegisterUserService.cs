using UnderAPILogin.Models;
using UnderAPILogin.Repositories;
using UnderAPILogin.Services;
using UnderAPILogin.Controllers;

namespace UnderAPILogin.Services
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IRegisterUserRepository _registerUserRepository;

        public RegisterUserService(IRegisterUserRepository registerUserRepository)
        {
            _registerUserRepository = registerUserRepository;
        }

        public void AddUser(User user)
        {
            _registerUserRepository.AddUser(user);
        }
    }
}