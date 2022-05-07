namespace Backend.Domain.Entity
{
    public class Skill
    {
        public Skill(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
