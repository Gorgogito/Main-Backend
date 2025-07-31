using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Main.Domain.Entity.Resource
{
    public class Program : CommonIdentity
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
        public string? CodeMenu { get; set; }

        [Required]
        [Column(Order = 4)]
        public string? Name { get; set; }

        [Required]
        [Column(Order = 5)]
        public string? Description { get; set; }

        [Required]
        [Column(Order = 6)]
        public int? Order { get; set; }

        [Required]
        [Column(Order = 7)]
        public string? PathProgram { get; set; }

        [Required]
        [Column(Order = 8)]
        public string? PathImage { get; set; }

    }
}
