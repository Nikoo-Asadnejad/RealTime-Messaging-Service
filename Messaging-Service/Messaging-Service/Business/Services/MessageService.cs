using Messaging_Service.Business.Dtos.Message;
using Messaging_Service.Business.Interfaces;
using Messaging_Service.DataAccess.Entities;
using Messaging_Service.DataAccess.Repository;

namespace Messaging_Service.Business.Services;
public class MessageService : IMessageService
{
  private readonly IUnitOfWork _unitOfWork;

  public MessageService(IUnitOfWork unitOfWork)
  {
    _unitOfWork = unitOfWork;
  }

  public async Task<List<MessageModel>> CreateMessageList(List<string> messages, long senderId , long chatId)
  {
    List < MessageModel > messagesList = new List < MessageModel >();
    messages.ForEach(async message => messagesList.Add(await CreateMessageAsync(message, senderId, chatId)));
    return messagesList;
  }
  public async Task<long?> CreateMessageAsync(CreateMessageDto createMessageDto)
  {
    MessageModel message = new(createMessageDto);
    await _unitOfWork.MessageRepository.AddAsync(message);
    await _unitOfWork.MessageRepository.SaveAsync();
    return message.Id;
  }

  public async Task<MessageModel> CreateMessageAsync(string content , long senderId , long chatId)
  {
    MessageModel message = new(content,senderId,chatId);
    await _unitOfWork.MessageRepository.AddAsync(message);
    await _unitOfWork.MessageRepository.SaveAsync();
    return message;
  }


}

