using System.Text.RegularExpressions;
using UnderAPILogin.Data;
using UnderAPILogin.Models;

namespace UnderAPILogin.Repositories
{
    public class RegisterUserRepository : IRegisterUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RegisterUserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(User user)
        {
            if (ValidNull(user))
            {
                throw new Exception($"Existem campos sem preenchimento!");
            }

            if (CheckUserExists(user.Email))
            {
                throw new Exception($"Usuário com o e-mail '{user.Email}' já existe.");
            }

            if (!ValidEmail(user.Email))
            {
                throw new Exception($"O e-mail: '{user.Email}' não é valido.");
            }

            try
            {
                _dbContext.User.Add(user);

                _dbContext.SaveChanges();

                Console.WriteLine($"Usuário '{user.Email}' cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar usuário: {ex.Message}");
                throw;
            }
        }

        public bool CheckUserExists(string email)
        {
            return _dbContext.User.Any(existingUser => existingUser.Email == email);
        }

        public bool ValidNull<T>(T obj)
        {
            return typeof(T).GetProperties().Any(a => string.IsNullOrEmpty(a.GetValue(obj)?.ToString()));
        }

        public bool ValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
                return regex.IsMatch(email);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}