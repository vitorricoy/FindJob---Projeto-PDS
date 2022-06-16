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
        public User? AssignedFreelancer { get; set; }
        public List<User> Candidates { get; set; }
        public bool Active { get; set; }
        public bool Available { get; set; }

        public Job(string id, string title, string description, int deadline, double payment, bool isPaymentByHour, List<Skill> skills, User client, User? assignedFreelancer, List<User> candidates, bool active, bool available)
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
            Candidates = candidates;
            Active = active;
            Available = available;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            return Equals((Job)obj);
        }

        public bool Equals(Job obj)
        {
            bool isAssignedFreelancerEqual = obj.AssignedFreelancer != null ? obj.AssignedFreelancer.Equals(AssignedFreelancer) : AssignedFreelancer == null;
            return obj != null && obj.Id.Equals(Id) && obj.Title.Equals(Title) && obj.Description.Equals(Description) && obj.Deadline.Equals(Deadline) && obj.Payment.Equals(Payment) && obj.IsPaymentByHour.Equals(IsPaymentByHour) && Enumerable.SequenceEqual(obj.Skills.OrderBy(s => s.NormalizedName), Skills.OrderBy(s => s.NormalizedName)) && obj.Client.Equals(Client) && isAssignedFreelancerEqual && Enumerable.SequenceEqual(obj.Candidates.OrderBy(c => c.Id), Candidates.OrderBy(c => c.Id)) && obj.Active.Equals(Active) && obj.Available.Equals(Available);
        }
    }
}
