namespace Backend.Domain.Entity
{
    public class Job
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int deadline { get; set; }
        public double payment { get; set; }
        public bool isPaymentByHour { get; set; }
        public List<Skill> skills { get; set; }
    }
}
