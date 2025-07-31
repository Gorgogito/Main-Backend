using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Main.Domain.Entity.Resource
{
    public class AccessControl : CommonIdentity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        [Key]
        [Required]
        public string? Code { get; set; }

        [Required]
        [Column(Order = 2)]
        public string? CodeResource { get; set; }

        [Required]
        [Column(Order = 3)]
        public string? CodeProgram { get; set; }

        [Required]
        [Column(Order = 4)]
        public bool? Read { get; set; }

        [Required]
        [Column(Order = 5)]
        public bool? Write { get; set; }

        [Required]
        [Column(Order = 6)]
        public bool? Create { get; set; }

        [Required]
        [Column(Order = 7)]
        public bool? Eliminate { get; set; }

    }
}
