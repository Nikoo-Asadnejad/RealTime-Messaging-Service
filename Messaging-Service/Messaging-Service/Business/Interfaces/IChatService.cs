using Messaging_Service.Business.Dtos.Chat;

namespace Messaging_Service.Business.Interfaces;
public interface IChatService
{
  Task StartChatAsync(long senderId, string connectionId, List<string> messages);
  Task SendMessageAsync(string message, long chatId);
  Task<long?> GetChatByConnectionId(string connectionId);
}

