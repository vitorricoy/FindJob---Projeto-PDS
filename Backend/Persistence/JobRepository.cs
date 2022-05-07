using Backend.Domain.Repository;

namespace Backend.Persistence
{
    public class JobRepository : BaseRepository, IJobRepository
    {
        public JobRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
