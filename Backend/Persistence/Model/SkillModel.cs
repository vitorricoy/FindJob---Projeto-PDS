using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class SkillModel
    {
        public string Name { get; set; }

        [Key]
        public string NormalizedName { get; set; }

        public SkillModel(string name, string normalizedName)
        {
            Name = name;
            NormalizedName = normalizedName;
        }

        public SkillModel()
        {

        }

        public static SkillModel FromDomainObject(Skill skill)
        {
            return new SkillModel(skill.Name, skill.NormalizedName);
        }
    }
}
