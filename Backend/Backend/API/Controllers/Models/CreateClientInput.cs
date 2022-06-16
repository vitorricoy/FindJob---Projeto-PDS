namespace Backend.API.Controllers.Models
{
    public class CreateClientInput
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public CreateClientInput(string name, string email, string password, string phone)
        {
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
        }
    }
}
