namespace Backend.API.Controllers.Models
{
    public class RateJobInput
    {
        public int JobId { get; set; }
        public double Rating { get; set; }

        public RateJobInput(int jobId, double rating)
        {
            JobId = jobId;
            Rating = rating;
        }
    }
}
