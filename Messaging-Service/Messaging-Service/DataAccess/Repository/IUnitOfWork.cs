using GenericRepositoryDll.Repository.GenericRepository;
using Messaging_Service.DataAccess.Entities;

namespace Messaging_Service.DataAccess.Repository;
  public interface IUnitOfWork
  {
    IRepository<MessageModel> MessageRepository { get; }
    IRepository<ChatModel> ChatRepository { get; }
  }

