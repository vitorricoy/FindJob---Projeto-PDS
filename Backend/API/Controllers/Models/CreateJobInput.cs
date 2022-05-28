namespace Backend.API.Controllers.Models
{
    public class CreateJobInput
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Deadline { get; set; }
        public double Payment { get; set; }
        public bool IsPaymentByHour { get; set; }
        public List<string> Skills { get; set; }
        public string ClientId { get; set; }

        public string? AssignedFreelancerId;

        public CreateJobInput(string title, string description, int deadline, double payment, bool isPaymentByHour, List<string> skills, string clientId, string assignedFreelancerId)
        {
            Title = title;
            Description = description;
            Deadline = deadline;
            Payment = payment;
            IsPaymentByHour = isPaymentByHour;
            Skills = skills;
            ClientId = clientId;
            AssignedFreelancerId = assignedFreelancerId;
        }
    }
}
