using Backend.Domain.Repository;

namespace Backend.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository jobRepository;
        public UserService(IUserRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }
    }
}
