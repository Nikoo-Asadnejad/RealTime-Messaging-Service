using Messaging_Service.Business.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Messaging_Service.Business.Services;

public class ChatService :  IChatService
{

  public async Task StartChat(long senderId)
  {
  
  }

  public async Task StopChat(long chatId)
  {

  }

  public async Task SendMessage(string message , long chatId)
  {

  }

}

