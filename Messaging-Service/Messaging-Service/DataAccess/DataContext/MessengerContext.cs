using Messaging_Service.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messaging_Service.DataAccess.DataContext;
  public class MessengerContext : DbContext
  {
    public MessengerContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
      
    }

    DbSet<ChatModel> Chats { get; set; }
    DbSet<MessageModel> Messages { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<ChatModel>()
      .HasQueryFilter(c => c.DeletedBy == null && c.DeleteDate == null);

    modelBuilder.Entity<MessageModel>()
      .HasQueryFilter(m => m.DeletedBy == null && m.DeleteDate == null);

  }


  }

