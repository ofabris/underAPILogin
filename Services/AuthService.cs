using UnderAPILogin.Models;
using UnderAPILogin.Repositories;

namespace UnderAPILogin.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string Email, string Password)
        {
            return _userRepository.GetUserByEmailAndPassword(Email, Password);
        }
    }
}
