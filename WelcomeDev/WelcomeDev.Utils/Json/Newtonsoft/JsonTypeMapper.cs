using Newtonsoft.Json;

namespace WelcomeDev.Utils.Json.Newtonsoft
{
    public class JsonTypeMapper<TInterface, TImpl> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(TInterface));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<TImpl>(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
