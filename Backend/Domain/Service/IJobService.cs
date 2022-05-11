using Backend.Domain.Entity;

namespace Backend.Domain.Service
{
    public interface IJobService
    {
        public bool RateJob(int jobId, double rating);

        public List<Job> ListJobsByUser(int userId); 

        public List<Job> SearchJobsForFreelancer(int userId);

        public Job GetJobById(int jobId);
    }
}
