using Messaging_Service.Business.Dtos.Chat;
using Messaging_Service.Business.Interfaces;
using Messaging_Service.DataAccess.Entities;
using Messaging_Service.DataAccess.Repository;
using Microsoft.AspNetCore.SignalR;

namespace Messaging_Service.Business.Services;

public class ChatService :  IChatService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMessageService _messageService;

  public ChatService(IUnitOfWork unitOfWork , IMessageService messageService)
  {
    _unitOfWork = unitOfWork;
    _messageService = messageService;
  }

  public async Task StartChatAsync(long senderId , string connectionId , List<string> messages)
  {
    long? chatId = await CreateChatAsync(connectionId);
    List<MessageModel> messageses =await _messageService.CreateMessageList(messages,senderId,chatId.Value);
    await AddMessagesToChatAsync(chatId.Value, messageses);
  }

  public async Task<long?> GetChatByConnectionId(string connectionId)
   => await _unitOfWork.ChatRepository.GetSingleAsync<long>(query: c => c.ConnectionId == connectionId,
                                                            selector: c => c.Id);

  
  public async Task SendMessageAsync(string message , long chatId)
  {

  }

  private async Task<long?> CreateChatAsync(string connectionId)
  {
    ChatModel chat = new(connectionId);
    await _unitOfWork.ChatRepository.AddAsync(chat);
    await _unitOfWork.ChatRepository.SaveAsync();
    return chat.Id;
  }

  private async Task AddMessagesToChatAsync(long chatId , List<MessageModel> messages)
  {
    ChatModel chat = await _unitOfWork.ChatRepository.FindAsync(chatId);
    chat.Messages.AddRange(messages);
    await _unitOfWork.ChatRepository.SaveAsync();
  }

}

