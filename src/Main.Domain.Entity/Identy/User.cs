using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Domain.Entity.Identy
{
    public class User : CommonIdentity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        [Key]
        [Required]
        public string? UserName { get; set; }

        [Required]
        [Column(Order = 2)]
        public string? Password { get; set; }

        [Required]
        [Column(Order = 3)]
        public string? Description { get; set; }

        [Column(Order = 4)]
        public string? Names { get; set; }

        [Column(Order = 5)]
        public string? Surnames { get; set; }

        [Column(Order = 6)]
        public string? Phone { get; set; }

        [Column(Order = 7)]
        public string? EMail { get; set; }

    }
}
