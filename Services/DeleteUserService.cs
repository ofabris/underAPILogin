using UnderAPILogin.Models;
using UnderAPILogin.Repositories;
using UnderAPILogin.Services;

namespace UnderAPILogin.Services
{
    public class DeleteUserService: IDeleteUserService
    {
        private readonly IDeleteUserRepository _deleteUserRepository;

        public DeleteUserService(IDeleteUserRepository deleteUserRepository)
        {
            _deleteUserRepository = deleteUserRepository;
        }

        public User DeleteUser(User user)
        {
            return _deleteUserRepository.DeleteUser(user);
        }
    }
}