using Backend.Domain.Repository;

namespace Backend.Persistence
{
    public class SkillRepository : BaseRepository, ISkillRepository
    {
        public SkillRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
