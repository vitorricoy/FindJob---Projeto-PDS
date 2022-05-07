namespace Backend.Domain.Entity
{
    public class User
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public string Phone { get; }
        public bool IsFreelancer { get; }
        public Dictionary<Skill, double> Skills { get; }

        public User(int id, string name, string email, string password, string phone, bool isFreelancer, Dictionary<Skill, double> skills)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            IsFreelancer = isFreelancer;
            Skills = skills;
        }
    }
}
