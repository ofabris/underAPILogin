using UnderAPILogin.Data;
using UnderAPILogin.Models;

namespace UnderAPILogin.Repositories
{
    public class DeleteUserRepository : IDeleteUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteUserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User DeleteUser(User user)
        {
            try
            {
                User userToDelete = _dbContext.User.Find(user.Id);

                _dbContext.User.Remove(userToDelete);

                _dbContext.SaveChanges();

                Console.WriteLine($"Usuário '{userToDelete.Email}' removido com sucesso.");

                return userToDelete;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover usuário: {ex.Message}");
                throw;
            }
        }
    }
}