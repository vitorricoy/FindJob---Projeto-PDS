namespace Backend.API.Controllers.Models
{
    public class CreateFreelancerInput
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }
        public List<string> Skills { get; set; }
        public List<double> Ratings { get; set; }


        

        public CreateFreelancerInput(string name, string email, string password, string phone, List<string> skills, List<double> ratings)
        {
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            Skills = skills;
            Ratings = ratings;
            
        }
    }
}
