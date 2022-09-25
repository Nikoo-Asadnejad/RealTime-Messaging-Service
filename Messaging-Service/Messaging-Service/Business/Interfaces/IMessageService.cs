using Messaging_Service.Business.Dtos.Message;
using Messaging_Service.DataAccess.Entities;

namespace Messaging_Service.Business.Interfaces;
public interface IMessageService
{
  Task<long?> CreateMessageAsync(CreateMessageDto createMessageDto);
  Task<List<MessageModel>> CreateMessageList(List<string> messages, long senderId, long chatId);
}

