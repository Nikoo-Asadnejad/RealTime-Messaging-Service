namespace Messaging_Service.Business.Dtos.Message;
public class CreateMessageDto
{
  public long SenderId { get; set; }
  public long RecieverId { get; set; }
  public string Content { get; set; }
}

