using System.Text.Json;
using System.Text.Json.Serialization;
using BusinessLogic.Domain;

namespace BusinessLogic.Entry.JsonConfigurations;
public class BaseEntityJsonConverter : JsonConverter<BaseEntity>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeof(BaseEntity).IsAssignableFrom(typeToConvert);
    }
    public override BaseEntity? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var baseEntity = JsonSerializer.Deserialize(ref reader, typeToConvert, options);
        return baseEntity != null ? (BaseEntity)baseEntity : null;
    }


    public override void Write(Utf8JsonWriter writer, BaseEntity value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
