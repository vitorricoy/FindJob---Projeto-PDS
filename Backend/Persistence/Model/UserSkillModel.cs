using Backend.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Persistence.Model
{
    public class UserSkillModel
    {
        [Key]
        public UserModel User { get; set; }

        [ForeignKey("Id")]
        public SkillModel Skill { get; set; }

        public int RatingsDone { get; set; }

        public double Rating { get; set; }

        public UserSkillModel(UserModel user, SkillModel skill, int ratingsDone, double rating)
        {
            Skill = skill;
            User = user;
            RatingsDone = ratingsDone;
            Rating = rating;
        }

        public UserSkillModel()
        {

        }
   }
}
