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
  public async Task<long> CreateMessage(CreateMessageDto createMessageDto)
  {
    MessageModel message = new(createMessageDto);
    await _unitOfWork.MessageRepository.AddAsync(message);
    await _unitOfWork.MessageRepository.SaveAsync();
    return message.Id;
  }
}

