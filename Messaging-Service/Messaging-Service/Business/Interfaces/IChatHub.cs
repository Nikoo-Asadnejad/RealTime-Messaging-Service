namespace Messaging_Service.Business.Interfaces;

public interface IChatHub 
{
   Task RecieveMessage(long userId, string message);
  
  
}

