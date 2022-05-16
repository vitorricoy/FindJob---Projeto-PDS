namespace Backend.API.Controllers.Models
{
    public class CreateFreelancerInput
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public Dictionary<string, double> SkillRates;

        public CreateFreelancerInput(string name, string email, string password, string phone, Dictionary<string, double> skillRates)
        {
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            SkillRates = skillRates;
        }
    }
}
