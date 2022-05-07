namespace Backend.Domain.Entity
{
    public class Job
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Deadline { get; set; }
        public double Payment { get; set; }
        public bool IsPaymentByHour { get; set; }
        public List<Skill> Skills { get; set; }
        public User Client { get; set; }
        public User AssignedFreelancer;
        public bool Active { get; set; }
        public bool Available { get; set; }

        public Job(string id, string title, string description, int deadline, double payment, bool isPaymentByHour, List<Skill> skills, User client, User assignedFreelancer, bool active, bool available)
        {
            Id = id;
            Title = title;
            Description = description;
            Deadline = deadline;
            Payment = payment;
            IsPaymentByHour = isPaymentByHour;
            Skills = skills;
            Client = client;
            AssignedFreelancer = assignedFreelancer;
            Active = active;
            Available = available;
        }
    }
}
