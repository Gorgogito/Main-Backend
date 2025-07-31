using System.ComponentModel.DataAnnotations;

namespace Main.Domain.Entity
{
  public class CommonIdentity
  {    

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public string? CreatedBy { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public string? LastModifiedBy { get; set; }

  }
}
