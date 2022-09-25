using Messaging_Service.Business.Dtos.Chat;
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
  public virtual List<MessageModel> Messages { get; set; }

  public ChatModel(CreateChatDto createChatDto)
  {
    Messages = new List<MessageModel>();
    Messages.AddRange(createChatDto.Messages);
    ConnectionId = createChatDto.ConnectionId.Trim();
  }

  public ChatModel(string connectionId)
  {
    ConnectionId = connectionId.Trim();
    Messages = new List<MessageModel>();
  }

  public ChatModel()
  {
    Messages = new List<MessageModel>();
  }
}

