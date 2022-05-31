using Backend.Domain.Entity;

namespace Backend.Domain.Repository
{
    public interface IJobRepository
    {
        public Job GetJobById(string jobId);
        public List<Job> ListJobsByUser(string userId, bool isFreelancer);
        public List<Job> GetAllAvailableJobs();
        public void UpdateJob(Job job);
        public void AddJobCandidate(Job job, User freelancer);
        public void SetJobFreelancer(Job job, User freelancer);
        public Job CreateNewJob(Job job);
    }
}
