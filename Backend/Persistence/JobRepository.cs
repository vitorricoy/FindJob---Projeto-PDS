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
                    .Where(j => j.AssignedFreelancer != null && j.AssignedFreelancer.Id == userId)
                    .ToList()
                    .Select(j => ToDomainObject(j))
                    .ToList();
            } else
            {
                return dbContext.Jobs
                    .Where(j => j.Client != null && j.Client.Id == userId)
                    .ToList()
                    .Select(j => ToDomainObject(j))
                    .ToList();
            }
        }

        public void SetJobAsDone(string jobId)
        {
            JobModel jobModel = dbContext.Jobs.Where(j => j.Id.Equals(jobId)).First();

            jobModel.Active = false;

            dbContext.Jobs.Update(jobModel);

            dbContext.SaveChanges();
        }

        
    }
}
