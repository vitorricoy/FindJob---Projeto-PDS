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

            User domainUser = ToDomainObject(user);

            dbContext.SaveChanges();
            return domainUser;
        }

        public User GetUserById(string id)
        {
            UserModel entity = dbContext.Users.Where(u => u.Id == id).FirstOrDefault();
            User user = ToDomainObject(entity);
            dbContext.Entry<UserModel>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            dbContext.SaveChanges();
            return user;
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
