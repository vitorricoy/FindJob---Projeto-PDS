using Backend.Domain.Entity;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backend.API.Controllers.Converters
{
    public class DictionarySkillConverter : JsonConverter<Dictionary<Skill, Tuple<double, int>>>
    {
        public override Dictionary<Skill, Tuple<double, int>>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<Skill, Tuple<double, int>> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            foreach (KeyValuePair<Skill, Tuple<double, int>> item in value)
            {
                writer.WritePropertyName(item.Key.ToString());
                writer.WriteStartArray();
                writer.WriteNumberValue(item.Value.Item1);
                writer.WriteNumberValue(item.Value.Item2);
                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }
    }
}
