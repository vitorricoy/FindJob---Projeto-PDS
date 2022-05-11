using Backend.Domain.Entity;
using Backend.Domain.Repository;

namespace Backend.Domain.Service
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository skillRepository;
        public SkillService(ISkillRepository skillRepository)
        {
            this.skillRepository = skillRepository;
        }

        public Skill CreateNewSkill(string name)
        {
            string normalizedName = name.ToLower().Replace(" ", "");
            return skillRepository.CreateNewSkill(new Skill(0, name, normalizedName));
        }

        public List<Skill> GetAllSkills()
        {
            return skillRepository.GetAllSkills();
        }
    }
}
