using System.ComponentModel.DataAnnotations.Schema;

namespace UnderAPILogin.Models
{
    [Table("TB_MUSIC")]
    public class Music
    {
        [Column("ID_MUSIC")]
        public int Id { get; set; }

        [Column("ID_USER")]
        public int? IdUser { get; set; }

        [Column("MUSIC_LINK")]
        public string? Link { get; set; }

        [Column("DT_INSERT")]
        public DateTime? DateInsert { get; set; }

        [Column("MUSIC_GENDER")]
        public string? GenderMusic { get; set; }
    }
}