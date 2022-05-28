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
                throw new AlreadyRegisteredUserException();
            }

            User newUser = new User(Guid.NewGuid().ToString(), name, email, hashedPassword, phone, false, null);

            userRepository.CreateNewUser(newUser);

            return newUser;
        }

        public User RegisterFreelancer(string name, string email, string password, string phone, Dictionary<string,double> ratedSkills)
        {
            string hashedPassword = HashingUtil.getHash(password);
            User findUser = userRepository.GetUserByEmail(email);

            if (findUser != null)
            {
                throw new AlreadyRegisteredUserException();
            }

            Dictionary<Skill, Tuple<double, int>> skills = new Dictionary<Skill, Tuple<double, int>>();
            string skillName,skillNormalizedName;

            foreach(KeyValuePair<string,double> entry in ratedSkills)
            {
                skillName = entry.Key;
                skillNormalizedName = skillName.ToLower().Replace(" ", "");
                skills.Add(new Skill(skillName, skillNormalizedName), new Tuple<double, int>(entry.Value, 1));
            }

            User newUser = new User(Guid.NewGuid().ToString(), name, email, hashedPassword, phone, true, skills);

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
