using System.Text.Json;
using System.Text.Json.Serialization;

namespace IEditableObjectTest.Objects
{
    public class DepthControlConverter<T> : JsonConverter<T>
    {
        private readonly int _maxDepth;

        public DepthControlConverter(int maxDepth)
        {
            _maxDepth = maxDepth;
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<T>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            Write(writer, value, options, 0);
        }

        private void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options, int currentDepth)
        {
            if (currentDepth > _maxDepth || value == null)
            {
                JsonSerializer.Serialize(writer, (object)null, options);
                return;
            }

            Type type = value.GetType();
            writer.WriteStartObject();

            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
            {
                object? propertyValue = property.GetValue(value);
                writer.WritePropertyName(property.Name);
                Write(writer, propertyValue, options, currentDepth + 1);
            }

            writer.WriteEndObject();
        }
    }
}
