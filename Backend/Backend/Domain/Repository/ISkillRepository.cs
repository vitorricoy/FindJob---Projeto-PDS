using Backend.Domain.Entity;

namespace Backend.Domain.Repository
{
    public interface ISkillRepository
    {
        public Skill CreateNewSkill(Skill skill);
        public List<Skill> GetAllSkills();

    }
}
