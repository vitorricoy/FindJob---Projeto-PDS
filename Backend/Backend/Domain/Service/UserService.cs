using Backend.Domain.Entity;
using Backend.Domain.Exceptions;
using Backend.Domain.Repository;
using Backend.Util;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User RegisterClient(string name, string email, string password, string phone)
        {
            string hashedPassword = HashingUtil.getHash(password);
            User findUser = userRepository.GetUserByEmail(email);

            if (findUser != null)
            {
                throw new InvalidSignUpCredentialsException();
            }

            User newUser = new User(Guid.NewGuid().ToString(), name, email, hashedPassword, phone, false, null);

            userRepository.CreateNewUser(newUser);

            return newUser;
        }

        public User RegisterFreelancer(string name, string email, string password, string phone, List<string> skills, List<double> ratings)
        {
            string hashedPassword = HashingUtil.getHash(password);
            User findUser = userRepository.GetUserByEmail(email);

            if (findUser != null)
            {
                throw new InvalidSignUpCredentialsException();
            }

            Dictionary<Skill, Tuple<double, int>> skillsDict = Enumerable.Range(0, Math.Min(skills.Count, ratings.Count))
                                                                         .ToDictionary(i => new Skill(skills[i], skills[i].ToLower().Replace(" ", "")), 
                                                                                       i => new Tuple<double, int>(ratings[i], 1));

            User newUser = new User(Guid.NewGuid().ToString(), name, email, hashedPassword, phone, true, skillsDict);

            userRepository.CreateNewUser(newUser);

            return newUser;
        }

        public User Login(string email, string password)
        {
            string hashedPassword = HashingUtil.getHash(password);
            User loggedUser = userRepository.GetUserByEmail(email);

            if(loggedUser == null || loggedUser.Password != hashedPassword)
            {
                throw new InvalidLoginCredentialsException();
            }

            return loggedUser;
        }

        public User GetUserById(string id)
        {
            return userRepository.GetUserById(id);
        }

    }
}
