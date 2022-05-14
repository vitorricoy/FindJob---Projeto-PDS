using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class UserProficiencyModel
    {
        [Key]
        [ForeignKey("Id")]
        public virtual UserModel Freelancer { get; set; }

        [Key]
        [ForeignKey("Id")]
        public virtual SkillModel Skill { get; set; }

        public double Rating { get; set; }
        public int RatingsDone { get; set; }

        public UserProficiencyModel(UserModel freelancer, SkillModel skill, double rating, int ratingsDone)
        {
            Freelancer = freelancer;
            Skill = skill;
            Rating = rating;
            RatingsDone = ratingsDone;
        }

        public UserProficiencyModel()
        {

        }

        public static List<UserProficiencyModel> FromUserDomainObject(User user)
        {
            List<UserProficiencyModel> proficiency_models = new List<UserProficiencyModel>();
            foreach(KeyValuePair<Skill,Tuple<double,int>> entry in user.Skills){
                proficiency_models.Add(new UserProficiencyModel(UserModel.FromDomainObject(user), SkillModel.FromDomainObject(entry.Key), entry.Value.Item1, entry.Value.Item2));
            }
            
            return proficiency_models;
        }
    }
}
