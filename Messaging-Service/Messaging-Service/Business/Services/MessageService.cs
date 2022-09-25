using Messaging_Service.Business.Dtos.Message;
using Messaging_Service.Business.Interfaces;

namespace Messaging_Service.Business.Services;
public class MessageService : IMessageService
{
  public Task<long> CreateMessage(CreateMessageDto createMessageDto)
  {
    throw new NotImplementedException();
  }
}

