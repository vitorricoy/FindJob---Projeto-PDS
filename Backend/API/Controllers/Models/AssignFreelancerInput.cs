namespace Backend.API.Controllers.Models
{
    public class AssignFreelancerInput
    {
        public string JobId { get; set; }
        public string FreelancerId { get; set; }

        public AssignFreelancerInput(string jobId, string freelancerId)
        {
            JobId = jobId;
            FreelancerId = freelancerId;
        }
    }
}
