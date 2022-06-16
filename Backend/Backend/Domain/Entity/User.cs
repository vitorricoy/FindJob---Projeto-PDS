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

        private bool AreDictionariesEqual(Dictionary<Skill, Tuple<double, int>> dict1, Dictionary<Skill, Tuple<double, int>> dict2)
        {
            string dict1string = String.Join(",", dict1.OrderBy(kv => kv.Key.NormalizedName).Select(kv => kv.Key + ":" + String.Join("|", kv.Value)));
            string dict2string = String.Join(",", dict2.OrderBy(kv => kv.Key.NormalizedName).Select(kv => kv.Key + ":" + String.Join("|", kv.Value)));

            return dict1string.Equals(dict2string);
        }

        public bool Equals(User obj)
        {
            return obj != null && obj.Email.Equals(Email) && obj.Id.Equals(Id) && obj.Name.Equals(Name) && obj.Password.Equals(Password) && obj.Phone.Equals(Phone) && obj.IsFreelancer.Equals(IsFreelancer) && AreDictionariesEqual(obj.Skills, Skills);
        }
    }
}
