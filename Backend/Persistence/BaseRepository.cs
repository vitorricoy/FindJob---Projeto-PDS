using Backend.Domain.Entity;
using Backend.Domain.Repository;

namespace Backend.Persistence
{
    public class BaseRepository
    {
        protected readonly ApplicationDbContext dbContext;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected Job ToDomainObject(JobModel jobMod)
        {
            if (jobMod == null)
            {
                return null;
            }

            List<JobRequirementModel> skillPairs = dbContext.JobSkills.Where(js => js.Job.Id == jobMod.Id).ToList();
            List<Skill> skills = new List<Skill>();

            foreach (JobRequirementModel pair in skillPairs)
            {
                skills.Add(ToDomainObject(dbContext.Skills.Where(s => s.NormalizedName == pair.Skill.NormalizedName).First()));
            }

            List<JobCandidateModel> candPairs = dbContext.JobCandidates.Where(js => js.Job.Id == jobMod.Id).ToList();
            List<User> candidates = new List<User>();

            foreach (JobCandidateModel pair in candPairs)
            {
                candidates.Add(ToDomainObject(dbContext.Users.Where(u => u.Id == pair.Candidate.Id).First()));
            }

            return new Job(jobMod.Id, jobMod.Title, jobMod.Description, jobMod.Deadline, jobMod.Payment, jobMod.IsPaymentByHour, skills, ToDomainObject(jobMod.Client), ToDomainObject(jobMod.AssignedFreelancer), candidates, jobMod.Active, jobMod.Available);
        }

        protected User ToDomainObject(UserModel userMod)
        {
            if (userMod == null)
            {
                return null;
            }
            List<UserProficiencyModel> skillPairs = dbContext.UserSkills.Where(us => us.Freelancer.Id == userMod.Id).ToList();
            Dictionary<Skill, Tuple<double, int>> skills = new Dictionary<Skill, Tuple<double, int>>();

            foreach (UserProficiencyModel pair in skillPairs)
            {
                skills.Add(ToDomainObject(dbContext.Skills.Where(s => s.NormalizedName == pair.Skill.NormalizedName).First()),
                    new Tuple<double, int>(pair.Rating, pair.RatingsDone));
            }

            return new User(userMod.Id, userMod.Name, userMod.Email, userMod.Password, userMod.Phone, userMod.IsFreelancer, skills);
        }

        protected Message ToDomainObject(MessageModel mesMod)
        {
            if (mesMod == null)
            {
                return null;
            }

            User sender = ToDomainObject(mesMod.Sender);
            User receiver = ToDomainObject(mesMod.Receiver);
            return new Message(mesMod.Id, mesMod.Content, sender, receiver, mesMod.SentTime, mesMod.IsRead);
        }

        protected Skill ToDomainObject(SkillModel skillMod)
        {
            if (skillMod == null)
            {
                return null;
            }

            return new Skill(skillMod.Name, skillMod.NormalizedName);
        }
    }
}
