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

        public User Login(string email, string password)
        {
            string hashedPassword = HashingUtil.getHash(password);
            User loggedUser = userRepository.GetUserByEmailAndPasswordHash(email, hashedPassword);

            if(loggedUser == null)
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
