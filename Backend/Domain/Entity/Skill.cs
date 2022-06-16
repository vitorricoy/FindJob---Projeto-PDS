using System.Text;

namespace Backend.Domain.Entity
{
    public class Skill
    {
        public string Name { get; set; }
        
        public string NormalizedName { get; set; }

        public Skill(string name, string normalizedName)
        {
            Name = name;
            NormalizedName = normalizedName;
        }

        public override string ToString()
        {
            return NormalizedName;
        }


        public override int GetHashCode()
        {
            return NormalizedName.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            return Equals((Skill)obj);
        }

        public bool Equals(Skill obj)
        {
            return obj != null && obj.NormalizedName.Equals(NormalizedName);
        }
    }
}
