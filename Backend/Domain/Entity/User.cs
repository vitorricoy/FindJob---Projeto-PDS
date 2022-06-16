namespace Backend.Domain.Entity
{
    public class User
    {
        public string Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public string Phone { get; }
        public bool IsFreelancer { get; }
        public Dictionary<Skill, Tuple<double, int>> Skills { get; }

        public User(string id, string name, string email, string password, string phone, bool isFreelancer, Dictionary<Skill, Tuple<double, int>> skills)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            IsFreelancer = isFreelancer;
            Skills = skills;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            return Equals((User)obj);
        }

        public bool Equals(User obj)
        {
            return obj != null && obj.Email.Equals(Email) && obj.Id.Equals(Id) && obj.Name.Equals(Name) && obj.Password.Equals(Password) && obj.Phone.Equals(Phone) && obj.IsFreelancer.Equals(IsFreelancer) && Enumerable.SequenceEqual(obj.Skills, Skills);
        }
    }
}
