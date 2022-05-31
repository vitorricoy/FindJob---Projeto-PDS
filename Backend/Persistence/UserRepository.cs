using Backend.Domain.Entity;
using Backend.Domain.Repository;

namespace Backend.Persistence
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public User GetUserByEmail(string email)
        {
            UserModel user = dbContext.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();

            return ToDomainObject(user);
        }

        public User GetUserById(string id)
        {
            return ToDomainObject(dbContext.Users.Where(u => u.Id == id).FirstOrDefault());
        }

        public User UpdateUser(User user)
        {
            User returnValue = ToDomainObject(dbContext.Users.Update(UserModel.FromDomainObject(user)).Entity);
            dbContext.SaveChanges();
            return returnValue;
        }

        public User CreateNewUser(User user)
        {
            if(user.IsFreelancer)
            {
                foreach(KeyValuePair<Skill,Tuple<double,int>> skillRate in user.Skills)
                {
                    if(!dbContext.Skills.Any(s => s.NormalizedName == skillRate.Key.NormalizedName))
                    {
                        dbContext.Skills.Add(SkillModel.FromDomainObject(skillRate.Key));
                    }
                }

                dbContext.UserSkills.AddRange(UserProficiencyModel.FromUserDomainObject(user));
            }
            
            User returnValue = ToDomainObject(dbContext.Users.Add(UserModel.FromDomainObject(user)).Entity);
            
            dbContext.SaveChanges();
            
            return returnValue;
        }
    }
}
