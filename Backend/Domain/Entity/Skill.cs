namespace Backend.Domain.Entity
{
    public class Skill
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public Skill(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override int GetHashCode()
        {
            return Id;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return Equals(obj as Skill);
        }

        public bool Equals(Skill obj)
        {
            return obj != null && obj.Id == this.Id;
        }
    }
}
