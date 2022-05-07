using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class SkillEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }

        public Skill ToDomainObject()
        {
            return new Skill(Id, Name);
        }

        public SkillEntity(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public static SkillEntity FromDomainObject(Skill skill)
        {
            return new SkillEntity(skill.Id, skill.Name);
        }
    }
}
