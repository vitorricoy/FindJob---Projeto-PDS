using Backend.Domain.Entity;
using Backend.Domain.Repository;

namespace Backend.Persistence
{
    public class JobRepository : BaseRepository, IJobRepository
    {
        public JobRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public List<Job> GetAllAvailableJobs()
        {
            return dbContext.Jobs
                .Where(j => j.Available)
                .ToList()
                .Select(j => ToDomainObject(j))
                .ToList();
        }

        public Job GetJobById(string jobId)
        {
            return ToDomainObject(dbContext.Jobs.Where(j => j.Id.Equals(jobId)).First());
        }

        public List<Job> ListJobsByUser(string userId, bool isFreelancer)
        {
            if (isFreelancer)
            {
                return dbContext.Jobs
                    .Where(j => j.AssignedFreelancer != null && j.AssignedFreelancer.Id == userId && j.Active)
                    .ToList()
                    .Select(j => ToDomainObject(j))
                    .ToList();
            } else
            {
                return dbContext.Jobs
                    .Where(j => j.Client != null && j.Client.Id == userId && j.Active)
                    .ToList()
                    .Select(j => ToDomainObject(j))
                    .ToList();
            }
        }

        public Job CreateNewJob(Job job)
        {
            Job returnValue = ToDomainObject(dbContext.Jobs.Add(JobModel.FromDomainObject(job)).Entity);
            
            dbContext.SaveChanges();
            
            return returnValue;
        }

        public void UpdateJob(Job job)
        {

            dbContext.Jobs.Update(JobModel.FromDomainObject(job));
        }
    }
}
