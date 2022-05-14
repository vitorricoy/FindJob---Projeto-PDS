using Backend.Domain.Entity;
using Backend.Domain.Repository;

namespace Backend.Persistence
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public User GetUserByEmailAndPasswordHash(string email, string password)
        {
            UserModel user = dbContext.Users.Where(u => u.Email.Equals(email) && u.Password.Equals(password)).First();

            return ToDomainObject(user);
        }

        public User GetUserById(string id)
        {
            return ToDomainObject(dbContext.Users.Where(u => u.Id == id).First());
        }

        public User UpdateUser(User user)
        {
            User returnValue = ToDomainObject(dbContext.Users.Update(UserModel.FromDomainObject(user)).Entity);
            dbContext.SaveChanges();
            return returnValue;
        }
    }
}
