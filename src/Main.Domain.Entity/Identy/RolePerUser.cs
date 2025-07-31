using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Main.Domain.Entity.Identy
{
    public class RolePerUser : CommonIdentity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        [Key]
        [Required]
        public string? UserName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 2)]
        [Key]
        [Required]
        public string? CodeRole { get; set; }

    }
}
