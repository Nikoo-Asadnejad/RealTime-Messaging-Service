using Messaging_Service.Business.Dtos.Message;

namespace Messaging_Service.Business.Interfaces;
public interface IMessageService
{
  Task<long> CreateMessage(CreateMessageDto createMessageDto);
}

