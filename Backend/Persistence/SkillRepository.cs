using Backend.Domain.Entity;
using Backend.Domain.Repository;

namespace Backend.Persistence
{
    public class SkillRepository : BaseRepository, ISkillRepository
    {
        public SkillRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public Skill CreateNewSkill(Skill skill)
        {
            Skill returnValue = ToDomainObject(dbContext.Skills.Add(SkillModel.FromDomainObject(skill)).Entity);
            dbContext.SaveChanges();
            return returnValue;
        }

        public List<Skill> GetAllSkills()
        {
            return dbContext.Skills.ToList().Select(s => ToDomainObject(s)).ToList();
        }
    }
}
