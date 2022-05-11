namespace Backend.API.Controllers.Models
{
    public class CreateSkillInput
    {
        public string Name { get; set; }

        public CreateSkillInput(string name)
        {
            Name = name;
        }
    }
}
