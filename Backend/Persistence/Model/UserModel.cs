using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public string Phone { get; }
        public bool IsFreelancer { get; }
        public Dictionary<SkillModel, Tuple<double, int>> Skills { get; }
        private UserModel(int id, string name, string email, string password, string phone, bool isFreelancer, Dictionary<SkillModel, Tuple<double, int>> skills)
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
            Dictionary<Skill, Tuple<double, int>> domainSkills = Skills.ToDictionary(kv => kv.Key.ToDomainObject(), kv => kv.Value);
            return new User(Id, Name, Email, Password, Phone, IsFreelancer, domainSkills);
        }

        public static UserModel FromDomainObject(User user)
        {
            return new UserModel(user.Id, user.Name, user.Email, user.Password, user.Phone, user.IsFreelancer, 
                user.Skills.ToDictionary(kv => SkillModel.FromDomainObject(kv.Key), kv => kv.Value));
        }
    }
}
