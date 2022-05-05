using Backend.Domain.Repository;

namespace Backend.Domain.Service
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository jobRepository;
        public SkillService(ISkillRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }
    }
}
