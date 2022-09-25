using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messaging_Service.DataAccess.Entities;
public class UserModel
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Required]
  public long Id { get; set; }

  [Required]
  public string FirstName { get; set; }

  [Required]
  public string LastName { get; set; }
}
