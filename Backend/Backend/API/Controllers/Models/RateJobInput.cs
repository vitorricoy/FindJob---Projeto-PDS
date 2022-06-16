namespace Backend.API.Controllers.Models
{
    public class RateJobInput
    {
        public string JobId { get; set; }
        public double Rating { get; set; }

        public RateJobInput(string jobId, double rating)
        {
            JobId = jobId;
            Rating = rating;
        }
    }
}
