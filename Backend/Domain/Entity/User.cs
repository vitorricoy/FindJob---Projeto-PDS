namespace Backend.Domain.Entity
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public bool isFreelancer { get; set; }
        public Dictionary<Skill, double> skills { get; set; }
    }
}
