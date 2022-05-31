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
            if (dbContext.Skills.Any(s => s.NormalizedName == skill.NormalizedName))
            {
                return ToDomainObject(dbContext.Skills.Where(s => s.NormalizedName == skill.NormalizedName).First());
            }

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
