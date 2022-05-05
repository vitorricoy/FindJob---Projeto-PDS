using Backend.Domain.Repository;

namespace Backend.Domain.Service
{
    public class JobService : IJobService
    {
        private readonly IJobRepository jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }
    }
}
