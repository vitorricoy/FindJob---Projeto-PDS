using Backend.Domain.Entity;

namespace Backend.Domain.Repository
{
    public interface IJobRepository
    {
        public Job GetJobById(string jobId);
        public void SetJobAsDone(string jobId);
        public List<Job> ListJobsByUser(string userId, bool isFreelancer);
        public List<Job> GetAllAvailableJobs();
        public void SetJobFreelancer(string jobId, User freelancer);
        public Job CreateNewJob(Job job);
    }
}
