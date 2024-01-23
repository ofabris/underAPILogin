using System;
using System.IO;
using System.Linq;
using UnderAPILogin.Models;

namespace UnderAPILogin.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string filePath;

        public UserRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public User GetUserByUsernameAndPassword(string email, string password)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 3 && parts[1] == email && parts[2] == password)
                    {
                        int userId;
                        if (int.TryParse(parts[0], out userId))
                        {
                            return new User { Id = userId, Email = parts[1], Password = parts[2] };
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler a base: {ex.Message}");
                return null;
            }
        }
    }
}
