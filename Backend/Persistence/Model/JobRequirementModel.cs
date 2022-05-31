using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class JobRequirementModel
    {
        [Key]
        [ForeignKey("Id")]
        public virtual JobModel Job { get; set; }

        [Key]
        [ForeignKey("Id")]
        public virtual SkillModel Skill { get; set; }


        public JobRequirementModel(JobModel job, SkillModel skill)
        {
            Job = job;
            Skill = skill;
       
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
                requirementModels.Add(new JobRequirementModel(JobModel.FromDomainObject(job), SkillModel.FromDomainObject(skill)));
            }

            return requirementModels;
        }
    }
}
