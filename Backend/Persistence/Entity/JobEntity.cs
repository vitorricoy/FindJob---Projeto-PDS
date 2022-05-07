using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class JobEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Deadline { get; set; }
        public double Payment { get; set; }
        public bool IsPaymentByHour { get; set; }
        public List<SkillEntity> Skills { get; set; }
        public UserEntity Client { get; set; }

        public JobEntity(string id, string title, string description, double payment, bool isPaymentByHour, List<SkillEntity> skills, UserEntity client)
        {
            Id = id;
            Title = title;
            Description = description;
            Payment = payment;
            IsPaymentByHour = isPaymentByHour;
            Skills = skills;
            Client = client;
        }

        public Job ToDomainObject()
        {
            List<Skill> domainSkills = Skills.Select(s => s.ToDomainObject()).ToList();
            return new Job(Id, Title, Description, Deadline, Payment, IsPaymentByHour, domainSkills, Client.ToDomainObject());
        }
        public static JobEntity FromDomainObject(Job job)
        {
            return new JobEntity(job.Id, job.Title, job.Description, job.Payment, job.IsPaymentByHour, 
                job.Skills.Select(s => SkillEntity.FromDomainObject(s)).ToList(), UserEntity.FromDomainObject(job.Client));
        }
    }
}
