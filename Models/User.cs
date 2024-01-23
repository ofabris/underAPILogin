
namespace UnderAPILogin.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string State { get; set; }
        public string County { get; set; } 
        public string District { get; set; }
        public string TypeUser { get; set; }
    }
}
