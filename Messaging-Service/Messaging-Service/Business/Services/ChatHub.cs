using Messaging_Service.Business.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Messaging_Service.Business.Services
{
  public class ChatHub : Hub<IChatHub>
  {
    public async override Task OnConnectedAsync()
    {
      await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");

      // add a chat recod with connectionID

      await base.OnConnectedAsync();
    }
    public async Task SendMessage(long userId, string message)
       => await Clients.Caller.RecieveMessage(userId , message);
  }
}
