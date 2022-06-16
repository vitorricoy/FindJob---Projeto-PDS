using Backend.Domain.Entity;

namespace Backend.API.Controllers.Models
{
    public class UserOutput
    {
        public string Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public string Phone { get; }
        public bool IsFreelancer { get; }
        public Dictionary<string, Tuple<double, int>> Skills { get; }

        public UserOutput(User domainUser)
        {
            Id = domainUser.Id;
            Name = domainUser.Name;
            Email = domainUser.Email;
            Password = domainUser.Password;
            Phone = domainUser.Phone;
            IsFreelancer = domainUser.IsFreelancer;
            Skills = domainUser.Skills.ToDictionary(kv => kv.Key.ToString(), kv => kv.Value);
        }
    }
}
