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
            if (user != null)
            {
                dbContext.Entry<UserModel>(user).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            User domainUser = ToDomainObject(user);
            dbContext.SaveChanges();
            return domainUser;
        }

        public User GetUserById(string id)
        {
            UserModel entity = dbContext.Users.Where(u => u.Id == id).FirstOrDefault();
            User user = ToDomainObject(entity);
            if (entity != null)
            {
                dbContext.Entry<UserModel>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            dbContext.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            UserModel entity = dbContext.Users.Update(UserModel.FromDomainObject(user)).Entity;
            dbContext.SaveChanges();
            dbContext.Entry<UserModel>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (user.IsFreelancer)
            {
                foreach (Skill skill in user.Skills.Keys)
                {
                    UserProficiencyModel userProficiency = new UserProficiencyModel(user.Id, skill.NormalizedName, user.Skills[skill].Item1, user.Skills[skill].Item2);
                    if (dbContext.UserSkills.Where(s => s.UserId.Equals(userProficiency.UserId) && s.SkillId.Equals(userProficiency.SkillId)).Any())
                    {
                        dbContext.UserSkills.Update(userProficiency);
                    } else
                    {
                        dbContext.UserSkills.Add(userProficiency);
                    }
                    dbContext.SaveChanges();
                }
            }

            User returnValue = ToDomainObject(entity);
            return returnValue;
        }

        public User CreateNewUser(User user)
        {
            UserModel entity = dbContext.Users.Add(UserModel.FromDomainObject(user)).Entity;
            dbContext.SaveChanges();

            if (user.IsFreelancer)
            {
                foreach(KeyValuePair<Skill,Tuple<double,int>> skillRate in user.Skills)
                {
                    if(!dbContext.Skills.Any(s => s.NormalizedName == skillRate.Key.NormalizedName))
                    {
                        dbContext.Skills.Add(SkillModel.FromDomainObject(skillRate.Key));
                        dbContext.SaveChanges();
                    }
                }

                dbContext.UserSkills.AddRange(UserProficiencyModel.FromUserDomainObject(user));
                dbContext.SaveChanges();
            }

            User returnValue = ToDomainObject(entity);

            return returnValue;
        }
    }
}
