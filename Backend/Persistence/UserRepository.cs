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

            return user.ToDomainObject();
        }

        public User GetUserById(int id)
        {
            return dbContext.Users.Where(u => u.Id == id).First().ToDomainObject();
        }

        public User UpdateUser(User user)
        {
            User returnValue = dbContext.Users.Update(UserModel.FromDomainObject(user)).Entity.ToDomainObject();
            dbContext.SaveChanges();
            return returnValue;
        }
    }
}
