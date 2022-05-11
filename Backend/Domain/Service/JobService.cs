using Backend.Domain.Entity;
using Backend.Domain.Exceptions;
using Backend.Domain.Repository;

namespace Backend.Domain.Service
{
    public class JobService : IJobService
    {
        private readonly IJobRepository jobRepository;
        private readonly IUserRepository userRepository;

        public JobService(IJobRepository jobRepository, IUserRepository userRepository)
        {
            this.jobRepository = jobRepository;
            this.userRepository = userRepository;
        }

        public List<Job> ListJobsByUser(int userId)
        {
            User user = userRepository.GetUserById(userId);

            if (user == null)
            {
                throw new InvalidUserIdException();
            }

            return jobRepository.ListJobsByUser(userId, user.IsFreelancer);
        }

        public List<Job> SearchJobsForFreelancer(int userId)
        {
            User user = userRepository.GetUserById(userId);

            if (user == null || !user.IsFreelancer)
            {
                throw new InvalidUserIdException();
            }

            List<Job> allJobs = jobRepository.GetAllAvailableJobs();

            List<Job> orderedJobs = allJobs.OrderByDescending(job =>
            {
                double score = 0.0;
                foreach (Skill skill in job.Skills)
                {
                    if (user.Skills.ContainsKey(skill))
                    {
                        score += user.Skills[skill].Item1 / job.Skills.Count;
                    }
                }
                return score;
            }).ToList();

            return orderedJobs;
        }

        public bool RateJob(int jobId, double rating)
        {
            Job job = jobRepository.GetJobById(jobId);
            if (job == null)
            {
                throw new InvalidJobIdException();
            }
            jobRepository.SetJobAsDone(jobId);

            User assignedFreelancer = job.AssignedFreelancer;

            foreach (Skill s in job.Skills)
            {
                if (assignedFreelancer.Skills.ContainsKey(s))
                {
                   Tuple<double, int> value = assignedFreelancer.Skills[s];
                   double newRating = (value.Item1 * value.Item2 + rating)/(value.Item2 + 1);
                    assignedFreelancer.Skills[s] = new Tuple<double, int>(newRating, value.Item2 + 1);
                } 
                else
                {
                    assignedFreelancer.Skills[s] = new Tuple<double, int>(rating, 1);
                }
            }

            job.AssignedFreelancer = assignedFreelancer;

            userRepository.UpdateUser(assignedFreelancer);

            return true;
        }

        public Job GetJobById(int jobId)
        {
            return jobRepository.GetJobById(jobId);
        }
    }
}
