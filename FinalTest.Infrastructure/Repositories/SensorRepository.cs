using FinalTest.Domain.Entities;

namespace FinalTest.Infrastructure.Repositories
{
    public class SensorRepository : BaseRepository<Sensor>
    {
        public SensorRepository(FinalTestDbContext dbContext) : base(dbContext)
        {
        }
    }
}
