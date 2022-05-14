using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class SkillModel
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public SkillModel(string id, string name, string normalizedName)
        {
            Id = id;
            Name = name;
            NormalizedName = normalizedName;
        }

        public SkillModel()
        {

        }

        public static SkillModel FromDomainObject(Skill skill)
        {
            return new SkillModel(skill.Id, skill.Name, skill.NormalizedName);
        }
    }
}
