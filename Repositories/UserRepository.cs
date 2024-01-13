using UnderAPILogin.Models;

namespace UnderAPILogin.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Email = "admin", Password = "@dmlogSYS1" }
        };

        public User GetUserByUsernameAndPassword(string email, string password)
        {
            return _users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
