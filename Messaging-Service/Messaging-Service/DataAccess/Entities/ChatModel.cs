using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messaging_Service.DataAccess.Entities;

[Table("Chat")]
public class ChatModel : BaseEntityModel
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Required]
  public long Id { get; set; }

  [Required]
  public string ConnectionId { get; set; }
  public virtual ICollection<MessageModel> Messages { get; set; }
}

