using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public string Phone { get; }
        public bool IsFreelancer { get; }
        public Dictionary<SkillEntity, double> Skills { get; }
        private UserEntity(int id, string name, string email, string password, string phone, bool isFreelancer, Dictionary<SkillEntity, double> skills)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            IsFreelancer = isFreelancer;
            Skills = skills;
        }

        public User ToDomainObject()
        {
            Dictionary<Skill, double> domainSkills = Skills.ToDictionary(kv => kv.Key.ToDomainObject(), kv => kv.Value);
            return new User(Id, Name, Email, Password, Phone, IsFreelancer, domainSkills);
        }

        public static UserEntity FromDomainObject(User user)
        {
            return new UserEntity(user.Id, user.Name, user.Email, user.Password, user.Phone, user.IsFreelancer, 
                user.Skills.ToDictionary(kv => SkillEntity.FromDomainObject(kv.Key), kv => kv.Value));
        }
    }
}
