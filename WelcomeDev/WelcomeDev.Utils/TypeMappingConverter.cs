using System.Text.Json;
using System.Text.Json.Serialization;

using WelcomeDev.Utils.Array;

namespace WelcomeDev.Utils
{
    public class TypeMappingConverter<TType, TImplementation> : JsonConverter<TType>
        where TImplementation : class, TType, new()
    {
        public override TType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<TImplementation>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, TType value, JsonSerializerOptions options)
        {
            var imp = value as TImplementation;
            if (imp != null)
            {
                JsonSerializer.Serialize(writer, imp, options);
                return;
            }

            var res = new TImplementation();
            typeof(TType).GetProperties()
                         .ForEach(x => res.GetType()
                                        .GetProperty(x.Name)
                                        .SetValue(res, x.GetValue(value)));

            JsonSerializer.Serialize(writer, res, options);
        }
    }
}
