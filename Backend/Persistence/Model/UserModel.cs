using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class UserModel
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsFreelancer { get; set; }
        
        public UserModel(String id, string name, string email, string password, string phone, bool isFreelancer)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            IsFreelancer = isFreelancer;
        }

        public UserModel()
        {

        }

        private UserModel(User user)
        {

            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
            Phone = user.Phone;
            IsFreelancer = user.IsFreelancer;
        }

  

        public static UserModel FromDomainObject(User user)
        {
            return new UserModel(user);
        }
    }
}
