using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class UserProficiencyModel
    {
        public string SkillId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel Freelancer { get; set; }

        [ForeignKey("SkillId")]
        public SkillModel Skill { get; set; }

        public double Rating { get; set; }
        public int RatingsDone { get; set; }

        public UserProficiencyModel(UserModel freelancer, SkillModel skill, double rating, int ratingsDone)
        {
            Freelancer = freelancer;
            Skill = skill;
            Rating = rating;
            RatingsDone = ratingsDone;
        }

        public UserProficiencyModel(string freelancer, string skill, double rating, int ratingsDone)
        {
            UserId = freelancer;
            SkillId = skill;
            Rating = rating;
            RatingsDone = ratingsDone;
        }

        public UserProficiencyModel()
        {

        }

        public static List<UserProficiencyModel> FromUserDomainObject(User user)
        {
            if (user == null)
            {
                return null;
            }

            List<UserProficiencyModel> proficiency_models = new List<UserProficiencyModel>();
            foreach(KeyValuePair<Skill,Tuple<double,int>> entry in user.Skills){
                proficiency_models.Add(new UserProficiencyModel(user.Id, entry.Key.NormalizedName, entry.Value.Item1, entry.Value.Item2));
            }
            
            return proficiency_models;
        }
    }
}
