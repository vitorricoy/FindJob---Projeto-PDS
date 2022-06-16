using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class JobRequirementModel
    {

        public string JobId { get; set; }

        public string SkillId { get; set; }


        [ForeignKey("JobId")]
        public JobModel Job { get; set; }

        [Key]
        [ForeignKey("SkillId")]
        public SkillModel Skill { get; set; }


        public JobRequirementModel(JobModel job, SkillModel skill)
        {
            Job = job;
            Skill = skill;
       
        }

        public JobRequirementModel(string job, string skill)
        {
            JobId = job;
            SkillId = skill;

        }

        public JobRequirementModel()
        {

        }

        public static List<JobRequirementModel> FromJobDomainObject(Job job)
        {
            if (job == null)
            {
                return null;
            }

            List<JobRequirementModel> requirementModels = new List<JobRequirementModel>();
            foreach (Skill skill in job.Skills)
            {
                requirementModels.Add(new JobRequirementModel(job.Id, skill.NormalizedName));
            }

            return requirementModels;
        }
    }
}
