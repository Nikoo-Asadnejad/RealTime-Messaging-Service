using Messaging_Service.Business.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Messaging_Service.Business.Services
{
  public class ChatHub : Hub<IChatHub>
  {
    private readonly IChatService _chatService;
    private string _connectionId;

    public ChatHub(IChatService chatService)
    {
      _chatService = chatService;
    }
    public async override Task OnConnectedAsync()
    {
   //   await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");

      _connectionId = Context.ConnectionId;

      // add a chat recod with connectionID

      await base.OnConnectedAsync();
    }
    public async Task SendMessage(long userId, string message)
    {
       
       await Clients.Caller.RecieveMessage(userId, message);
    }
       
  }
}
