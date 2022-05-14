using System.Text;

namespace Backend.Domain.Entity
{
    public class Skill
    {

        public string Id { get; set; }
        public string Name { get; set; }
        
        public string NormalizedName { get; set; }

        public Skill(string id, string name, string normalizedName)
        {
            Id = id;
            Name = name;
            NormalizedName = normalizedName;
        }

        
        public override int GetHashCode()
        {
            byte[] idBytes = Encoding.ASCII.GetBytes(Id);
            return BitConverter.ToInt32(idBytes);
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
