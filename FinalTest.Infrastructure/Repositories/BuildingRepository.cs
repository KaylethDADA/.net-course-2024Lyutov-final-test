using FinalTest.Domain.Entities;

namespace FinalTest.Infrastructure.Repositories
{
    public class BuildingRepository : BaseRepository<Building>
    {
        public BuildingRepository(FinalTestDbContext dbContext) : base(dbContext)
        {
        }
    }
}
