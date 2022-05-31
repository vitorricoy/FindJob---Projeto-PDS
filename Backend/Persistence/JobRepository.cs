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
            return ToDomainObject(dbContext.Jobs.Where(j => j.Id.Equals(jobId)).FirstOrDefault());
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

            foreach(Skill skill in job.Skills)
            {
                if (!dbContext.Skills.Any(s => s.NormalizedName == skill.NormalizedName))
                {
                    dbContext.Skills.Add(SkillModel.FromDomainObject(skill));
                }
            }

            dbContext.JobSkills.AddRange(JobRequirementModel.FromJobDomainObject(job));
            dbContext.JobCandidates.AddRange(JobCandidateModel.FromJobDomainObject(job));

            dbContext.SaveChanges();
            
            return returnValue;
        }

        public void UpdateJob(Job job)
        {

            dbContext.Jobs.Update(JobModel.FromDomainObject(job));
            
            foreach(JobRequirementModel jobSkill in JobRequirementModel.FromJobDomainObject(job))
            {
                if (!dbContext.JobSkills.Any(s => s.Job.Id == job.Id && s.Skill.NormalizedName == jobSkill.Skill.NormalizedName))
                {
                    dbContext.JobSkills.Add(jobSkill);
                }
            }

            foreach (JobCandidateModel jobCand in JobCandidateModel.FromJobDomainObject(job))
            {
                if (!dbContext.JobCandidates.Any(c => c.Job.Id == job.Id && c.Candidate.Id == jobCand.Candidate.Id))
                {
                    dbContext.JobCandidates.Add(jobCand);
                }
            }

            dbContext.SaveChanges();
        }
    }
}
