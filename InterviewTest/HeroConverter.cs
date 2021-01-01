using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest
{
    public class HeroConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<KeyValuePair<string, int>> list = value as List<KeyValuePair<string, int>>;
            writer.WriteStartArray();
            foreach (var item in list)
            {
                writer.WriteStartObject();
                writer.WritePropertyName(item.Key);
                writer.WriteValue(item.Value);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }


        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<KeyValuePair<string, int>>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
