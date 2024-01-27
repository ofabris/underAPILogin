using System.ComponentModel.DataAnnotations.Schema;

namespace UnderAPILogin.Models
{
    [Table ("TB_USER")]
    public class User
    {
        [Column("USER_ID")]
        public int Id { get; set; }

        [Column("USER_EMAIL")]
        public string? Email { get; set; }

        [Column("USER_PASSWORD")]
        public string? Password { get; set; }

        [Column("USER_STATE")]
        public string? State { get; set; }

        [Column("USER_COUNTY")]
        public string? County { get; set; }

        [Column("USER_DISTRICT")]
        public string? District { get; set; }

        [Column("USER_TYPE")]
        public bool? TypeUser { get; set; }
    }
}