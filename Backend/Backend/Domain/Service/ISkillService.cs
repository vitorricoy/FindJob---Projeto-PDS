using Backend.Domain.Entity;

namespace Backend.Domain.Service
{
    public interface ISkillService
    {
        public List<Skill> GetAllSkills();

        public Skill CreateNewSkill(string name);
    }
}
