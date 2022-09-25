using Microsoft.EntityFrameworkCore;

namespace Messaging_Service.DataAccess.DataContext;
  public class MessengerContext : DbContext
  {
    public MessengerContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

  }

