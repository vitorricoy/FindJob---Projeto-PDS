using Backend.Domain.Entity;
using Backend.Domain.Exceptions;
using Backend.Domain.Repository;

namespace Backend.Domain.Service
{
    public class JobService : IJobService
    {
        private readonly IJobRepository jobRepository;
        private readonly IUserRepository userRepository;
        private readonly ISkillRepository skillRepository;

        public JobService(IJobRepository jobRepository, IUserRepository userRepository, ISkillRepository skillRepository)
        {
            this.jobRepository = jobRepository;
            this.userRepository = userRepository;
            this.skillRepository = skillRepository;
        }

        public List<Job> ListJobsByUser(string userId)
        {
            User user = userRepository.GetUserById(userId);

            if (user == null)
            {
                throw new InvalidUserIdException();
            }

            return jobRepository.ListJobsByUser(userId, user.IsFreelancer);
        }

        public List<Job> SearchJobsForFreelancer(string userId)
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

        public bool RateJob(string jobId, double rating)
        {
            Job job = jobRepository.GetJobById(jobId);
            if (job == null || job.AssignedFreelancer == null)
            {
                throw new InvalidJobIdException();
            }

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

            job.Active = false;
            job.AssignedFreelancer = assignedFreelancer;

            jobRepository.UpdateJob(job);
            userRepository.UpdateUser(assignedFreelancer);

            return true;
        }

        public Job GetJobById(string jobId)
        {
            return jobRepository.GetJobById(jobId);
        }

        public Job CreateNewJob(string title, string description, int deadline, double payment, bool isPaymentByHour, List<string> skillNames, string clientId)
        {
            List<Skill> skills = new List<Skill>();
            string normalizedName;

            foreach(string skillName in skillNames){
                normalizedName = skillName.ToLower().Replace(" ", "");
                skills.Add(skillRepository.CreateNewSkill(new Skill(skillName,normalizedName)));
            }

            User client = userRepository.GetUserById(clientId);

            if (client == null)
            {
                throw new InvalidUserIdException();
            }

            Job newJob = new Job(Guid.NewGuid().ToString(), title, description, deadline, payment, isPaymentByHour, skills, client, null, new List<User>(),true, true);

            return jobRepository.CreateNewJob(newJob);
        }

        public bool CandidateForJob(string jobId, string freelancerId)
        {
            Job job = jobRepository.GetJobById(jobId);
            User freela = userRepository.GetUserById(freelancerId);

            if (job == null)
            {
                throw new InvalidJobIdException();
            }

            if (freela == null)
            {
                throw new InvalidUserIdException();
            }

            if (!job.Available)
            {
                throw new UnavailableJobException();
            }

            job.Candidates.Add(freela);
            jobRepository.UpdateJob(job);

            return true;
        }

        public bool ChooseFreelancerForJob(string jobId, string freelancerId)
        {
            Job job = jobRepository.GetJobById(jobId);
            User freela = userRepository.GetUserById(freelancerId);

            if(job == null)
            {
                throw new InvalidJobIdException();
            }

            if(freela == null || !(job.Candidates.Contains(freela)))
            {
                throw new InvalidUserIdException();
            }

            if(!job.Available)
            {
                throw new UnavailableJobException();
            }

            job.Available = false;
            job.AssignedFreelancer = freela;
            jobRepository.UpdateJob(job);

            return true;
        }
        private static int CompareCandidatesByJob(User cand1, User cand2, Job job)
        {
            List<double> ratings1 = new List<double>();
            List<double> ratings2 = new List<double>();
            
            foreach(Skill skill in job.Skills)
            {
                if (cand1.Skills.ContainsKey(skill))
                {
                    ratings1.Add(cand1.Skills[skill].Item1);
                }
                else
                {
                    ratings1.Add(0);
                }

                if (cand2.Skills.ContainsKey(skill))
                {
                    ratings2.Add(cand1.Skills[skill].Item1);
                }
                else
                {
                    ratings2.Add(0);
                }
            }
            
            return Math.Sign(ratings1.Average() - ratings2.Average());
        }

        public List<User> GetJobCandidatesBySkill(string jobId)
        {
            Job job = jobRepository.GetJobById(jobId);

            if(job == null)
            {
                throw new InvalidJobIdException();
            }

            job.Candidates.Sort((freela1, freela2) => CompareCandidatesByJob(freela1, freela2, job));

            return job.Candidates;
        }
    }
}
