using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Main.Domain.Entity.Resource
{
    public class Menu : CommonIdentity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        [Key]
        [Required]
        public string? Code { get; set; }
        
        [Required]
        [Column(Order = 2)]
        public string? CodeGroupMenu { get; set; }

        [Required]
        [Column(Order = 3)]
        public string? Name { get; set; }

        [Required]
        [Column(Order = 4)]
        public string? Description { get; set; }

        [Required]
        [Column(Order = 5)]
        public int? Order { get; set; }

        [Required]
        [Column(Order = 6)]
        public int? Level { get; set; }

    }
}
