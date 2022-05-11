using Backend.Persistence.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsFreelancer { get; set; }
        [ForeignKey("Id")]
        public List<UserSkillModel> Skills { get; }
        public UserModel(int id, string name, string email, string password, string phone, bool isFreelancer, List<UserSkillModel> skills)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            IsFreelancer = isFreelancer;
            Skills = skills;
        }

        public UserModel()
        {

        }

        private UserModel(User user)
        {
            List<UserSkillModel> userSkillModels = new List<UserSkillModel>();

            foreach (KeyValuePair<Skill, Tuple<double, int>> entry in user.Skills)
            {
                userSkillModels.Add(new UserSkillModel(this, SkillModel.FromDomainObject(entry.Key), entry.Value.Item2, entry.Value.Item1));
            }
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
            Phone = user.Phone;
            IsFreelancer = user.IsFreelancer;
            Skills = userSkillModels;
        }

        public User ToDomainObject()
        {
            Dictionary<Skill, Tuple<double, int>> domainSkills = new Dictionary<Skill, Tuple<double, int>>();
            foreach (UserSkillModel userSkill in Skills)
            {
                domainSkills.Add(userSkill.Skill.ToDomainObject(), new Tuple<double, int>(userSkill.Rating, userSkill.RatingsDone));
            }
            return new User(Id, Name, Email, Password, Phone, IsFreelancer, domainSkills);
        }

        public static UserModel FromDomainObject(User user)
        {
            return new UserModel(user);
        }
    }
}
