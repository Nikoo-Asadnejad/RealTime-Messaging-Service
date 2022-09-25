using Messaging_Service.Business.Dtos.Chat;
using Messaging_Service.Business.Dtos.Message;

namespace Messaging_Service.Business.Interfaces;
public interface IChatService
{
  Task StartChatAsync(long senderId, string connectionId, List<string> messages);
  Task SendMessageAsync(string message, long chatId);
  Task<long?> GetChatByConnectionIdAsync(string connectionId);
  Task AddMessagesToChatAsync(long chatId, long senderId, List<string> messages);
}

