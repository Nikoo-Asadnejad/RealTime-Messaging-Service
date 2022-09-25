namespace Messaging_Service.Business.Interfaces;
public interface IChatService
{
  Task StartChat(long senderId);
  Task StopChat(long chatId);
  Task SendMessage(string message, long chatId);
}

