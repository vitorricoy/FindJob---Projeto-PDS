using Backend.Domain.Entity;

namespace Backend.Domain.Repository
{
    public interface IUserRepository
    {
        public User GetUserByEmailAndPasswordHash(string email, string password);

        public User GetUserById(string id);

        public User UpdateUser(User user);
    }
}
