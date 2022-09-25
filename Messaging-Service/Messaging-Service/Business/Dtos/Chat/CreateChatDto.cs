using Messaging_Service.DataAccess.Entities;
namespace Messaging_Service.Business.Dtos.Chat;
public class CreateChatDto
{
  public List<MessageModel> Messages { get; set; }
  public string ConnectionId { get; set; }

  public CreateChatDto(MessageModel message , string connectionId)
  {
    Messages = new List<MessageModel>();
    Messages.Add(message);
    ConnectionId = connectionId.Trim();
  }

  public CreateChatDto(List<MessageModel> messages , string connectionId)
  {
    Messages = messages;
    ConnectionId = connectionId.Trim(); 
  }

  public CreateChatDto(string connectionId)
  {
    ConnectionId = connectionId.Trim();
    Messages = new List<MessageModel>();
  }

  public CreateChatDto()
  {

  }
}

