using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messaging_Service.DataAccess.Entities;

[Table("Message")]
public class MessageModel : BaseEntityModel
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Required]
  public long Id { get; set; }

  [Required]
  public long RecieverId { get; set; }

  [Required]
  public long SenderId { get; set; }

  [Required]
  public string Content { get; set; }

  public long? SendDate { get; set; }
  public long? ReciveDate { get; set; }
}

