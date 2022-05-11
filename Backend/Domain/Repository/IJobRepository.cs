using Backend.Domain.Entity;

namespace Backend.Domain.Repository
{
    public interface IJobRepository
    {
        public Job GetJobById(int jobId);
        public void SetJobAsDone(int jobId);
        public List<Job> ListJobsByUser(int userId, bool isFreelancer);
        public List<Job> GetAllAvailableJobs();
    }
}
