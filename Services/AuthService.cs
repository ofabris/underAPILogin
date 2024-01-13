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

        public User Authenticate(string username, string password)
        {
            return _userRepository.GetUserByUsernameAndPassword(username, password);
        }
    }
}
