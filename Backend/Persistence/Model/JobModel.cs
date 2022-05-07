using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class JobModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Deadline { get; set; }
        public double Payment { get; set; }
        public bool IsPaymentByHour { get; set; }
        public List<SkillModel> Skills { get; set; }
        public UserModel Client { get; set; }
        public UserModel AssignedFreelancer { get; set; }
        public bool Active { get; set; }
        public bool Available { get; set; }

        public JobModel(string id, string title, string description, double payment, bool isPaymentByHour, List<SkillModel> skills, UserModel client, UserModel assignedFreelancer, bool active, bool available)
        {
            Id = id;
            Title = title;
            Description = description;
            Payment = payment;
            IsPaymentByHour = isPaymentByHour;
            Skills = skills;
            Client = client;
            AssignedFreelancer = assignedFreelancer;
            Active = active;
            Available = available;
        }

        public Job ToDomainObject()
        {
            List<Skill> domainSkills = Skills.Select(s => s.ToDomainObject()).ToList();
            return new Job(Id, Title, Description, Deadline, Payment, IsPaymentByHour, domainSkills, Client.ToDomainObject(), 
                AssignedFreelancer.ToDomainObject(), Active, Available);
        }
        public static JobModel FromDomainObject(Job job)
        {
            return new JobModel(job.Id, job.Title, job.Description, job.Payment, job.IsPaymentByHour, 
                job.Skills.Select(s => SkillModel.FromDomainObject(s)).ToList(), UserModel.FromDomainObject(job.Client), 
                    UserModel.FromDomainObject(job.AssignedFreelancer), job.Active, job.Available);
        }
    }
}
