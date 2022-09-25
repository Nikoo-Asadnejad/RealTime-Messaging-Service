using GenericRepositoryDll.Repository.GenericRepository;
using Messaging_Service.DataAccess.Entities;

namespace Messaging_Service.DataAccess.Repository;
public class UnitOfWork : IUnitOfWork
{
  public IRepository<MessageModel> MessageRepository { get; private set; }

  public IRepository<ChatModel> ChatRepository { get; private set; }

  public UnitOfWork(IRepository<MessageModel> messageRepository , IRepository<ChatModel> chatRepository)
  {
    MessageRepository = messageRepository;
    ChatRepository = chatRepository;
  }
}

