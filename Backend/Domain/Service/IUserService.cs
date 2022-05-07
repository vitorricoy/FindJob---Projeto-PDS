using Backend.Domain.Entity;

namespace Backend.Domain.Service
{
    public interface IUserService
    {
        public User Login(string email, string password);

        public User GetUserById(int id);
    }
}
