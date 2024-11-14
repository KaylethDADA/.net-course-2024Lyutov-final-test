using FinalTest.Domain.Entities;

namespace FinalTest.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(FinalTestDbContext dbContext) : base(dbContext)
        {
        }

    }
}
