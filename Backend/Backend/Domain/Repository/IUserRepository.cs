using Backend.Domain.Entity;

namespace Backend.Domain.Repository
{
    public interface IUserRepository
    {
        public User GetUserByEmail(string email);

        public User GetUserById(string id);

        public User UpdateUser(User user);

        public User CreateNewUser(User user);
    }
}
