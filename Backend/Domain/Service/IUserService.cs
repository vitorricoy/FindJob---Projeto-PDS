using Backend.Domain.Entity;

namespace Backend.Domain.Service
{
    public interface IUserService
    {
        public User RegisterClient(string name, string email, string password, string phone);

        public User RegisterFreelancer(string name, string email, string password, string phone, List<string> skills, List<double> ratings);
        
        public User Login(string email, string password);

        public User GetUserById(string id);
    }
}
