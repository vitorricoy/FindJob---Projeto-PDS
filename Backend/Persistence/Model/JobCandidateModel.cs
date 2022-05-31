using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class JobCandidateModel
    {
        [Key]
        [ForeignKey("Id")]
        public virtual JobModel Job { get; set; }

        [Key]
        [ForeignKey("Id")]
        public virtual UserModel Candidate { get; set; }


        public JobCandidateModel(JobModel job, UserModel candidate)
        {
            Job = job;
            Candidate = candidate;
       
        }

        public JobCandidateModel()
        {

        }

        public static List<JobCandidateModel> FromJobDomainObject(Job job)
        {
            if (job == null)
            {
                return null;
            }

            List<JobCandidateModel> candidateModels = new List<JobCandidateModel>();
            foreach (User candidate in job.Candidates)
            {
                candidateModels.Add(new JobCandidateModel(JobModel.FromDomainObject(job), UserModel.FromDomainObject(candidate)));
            }

            return candidateModels;
        }
    }
}
