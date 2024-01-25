using UnderAPILogin.Data;
using UnderAPILogin.Models;

namespace UnderAPILogin.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserByEmailAndPassword(string Email, string Password)
        {
            try
            {
                var user = _dbContext.User.FirstOrDefault(u => u.Email == Email && u.Password == Password);

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar o banco de dados: {ex.Message}");
                return null;
            }
        }

    }
}