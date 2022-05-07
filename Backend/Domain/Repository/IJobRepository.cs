using Backend.Domain.Entity;

namespace Backend.Domain.Repository
{
    public interface IJobRepository
    {
        public Job GetJobById(int jobId);
        public void SetJobAsDone(int jobId);
        public List<Job> ListJobsByFreelancer(int userId);
        public List<Job> GetAllAvailableJobs();
    }
}
