using Backend.Domain.Entity;

namespace Backend.Domain.Service
{
    public interface IJobService
    {
        public bool RateJob(int jobId, double rating);

        public List<Job> ListJobsByFreelancer(int userId); 

        public List<Job> SearchJobsForFreelancer(int userId);
    }
}
