using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Main.Domain.Entity.Resource
{
    public class Resource : CommonIdentity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        [Key]
        [Required]
        public string? Code { get; set; }

        [Required]
        [Column(Order = 2)]
        public string? Name { get; set; }

        [Required]
        [Column(Order = 3)]
        public string? Description { get; set; }

    }
}
