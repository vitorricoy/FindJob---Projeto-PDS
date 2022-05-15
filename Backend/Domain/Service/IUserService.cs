using Backend.Domain.Entity;

namespace Backend.Domain.Service
{
    public interface IUserService
    {
        public User RegisterClient(string name, string email, string password, string phone);

        public User RegisterFreelancer(string name, string email, string password, string phone, Dictionary<string, double> skills);
        
        public User Login(string email, string password);

        public User GetUserById(string id);
    }
}
