using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnderAPILogin.Models;

namespace UnderAPILogin.Repositories
{
    public class RegisterUserRepository : IRegisterUserRepository
    {

        private readonly string filePath;
        private List<User> _users;

        public RegisterUserRepository(string filePath)
        {
            this.filePath = filePath;
            _users = LoadUsersFromFile();
        }

        public void AddUser(User user)
        {

            if (ValidNull(user))
            {
                throw new Exception($"Existem campos sem preenchimento!");
            }

            try
            {
                CheckUserExists(user.Email);

                _users.Add(user);

                WriteUsersToFile();

                Console.WriteLine($"Usuário '{user.Email}' cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
        }

        public bool ValidNull<T>(T obj)
        {
            return typeof(T).GetProperties().Any(a => string.IsNullOrEmpty(a.GetValue(obj)?.ToString()));
        }

        public void CheckUserExists(string email)
        {
            if (_users.Any(existingUser => existingUser.Email == email))
            {
                throw new Exception ($"Usuário com o e-mail '{email}' já existe.");
            }

            return;
        }

        private List<User> LoadUsersFromFile()
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                return lines.Select(line =>
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 3 && int.TryParse(parts[0], out int userId))
                    {
                        return new User { Id = userId, Email = parts[1], Password = parts[2] };
                    }
                    return null;
                })
                .Where(user => user != null)
                .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler a base: {ex.Message}");
                return new List<User>();
            }
        }

        private void WriteUsersToFile()
        {
            try
            {
                var lines = _users.Select(u => $"{u.Id};{u.Email};{u.Password}");

                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao escrever no arquivo: {ex.Message}");
            }
        }
    }
}
