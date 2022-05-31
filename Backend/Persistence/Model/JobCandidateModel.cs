using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class JobCandidateModel
    {
        public string JobId { get; set; }

        public string CandidateId { get; set; }


        [ForeignKey("JobId")]
        public virtual JobModel Job { get; set; }

        [ForeignKey("CandidateId")]
        public virtual UserModel Candidate { get; set; }


        public JobCandidateModel(JobModel job, UserModel candidate)
        {
            Job = job;
            Candidate = candidate;
       
        }

        public JobCandidateModel(string job, string candidate)
        {
            JobId = job;
            CandidateId = candidate;

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
                candidateModels.Add(new JobCandidateModel(job.Id, candidate.Id));
            }

            return candidateModels;
        }
    }
}
