using FinalTest.Domain.Entities;

namespace FinalTest.Infrastructure.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>
    {
        public NotificationRepository(FinalTestDbContext dbContext) : base(dbContext)
        {
        }
    }
}
