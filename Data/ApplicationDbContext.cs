using Microsoft.EntityFrameworkCore;
using UnderAPILogin.Models;

namespace UnderAPILogin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Music> Music { get; set; }
    }
}
