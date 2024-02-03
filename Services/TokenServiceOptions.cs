using System.ComponentModel.DataAnnotations;

namespace UnderAPILogin.Services
{
    public class TokenServiceOptions
    {
        [Required]
        public string Secret { get; set; }

        [Required]
        public string Issuer { get; set; }
    }
}