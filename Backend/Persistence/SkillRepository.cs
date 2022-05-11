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
            Skill returnValue = dbContext.Skills.Add(SkillModel.FromDomainObject(skill)).Entity.ToDomainObject();
            dbContext.SaveChanges();
            return returnValue;
        }

        public List<Skill> GetAllSkills()
        {
            return dbContext.Skills.ToList().Select(s => s.ToDomainObject()).ToList();
        }
    }
}
