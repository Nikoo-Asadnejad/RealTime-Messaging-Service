using Messaging_Service.AppConstants;
using Messaging_Service.Business.Dtos.Message;
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

  [ForeignKey("ChatId")]
  public long ChatId { get; set; }

  [ForeignKey("ChatId")]
  public virtual ChatModel Chat { get;set; }

  public MessageModel()
  {

  }

  public MessageModel(CreateMessageDto createMessageDto)
  {
    this.Content = createMessageDto.Content;
    this.SenderId = createMessageDto.SenderId;
    this.SendDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    this.RecieverId = createMessageDto.RecieverId ?? UserIds.AdminId;
    this.ChatId = createMessageDto.ChatId;
  }
}

