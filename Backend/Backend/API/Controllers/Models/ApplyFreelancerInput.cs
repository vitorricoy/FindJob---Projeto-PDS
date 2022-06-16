namespace Backend.API.Controllers.Models
{
    public class ApplyFreelancerInput
    {
        public string JobId { get; set; }
        public string FreelancerId { get; set; }

        public ApplyFreelancerInput(string jobId, string freelancerId)
        {
            JobId = jobId;
            FreelancerId = freelancerId;
        }
    }
}