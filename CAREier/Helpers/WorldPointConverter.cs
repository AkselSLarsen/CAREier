using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier
{
    public class WorldPointConverter : Newtonsoft.Json.JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            WorldPoint obj = (WorldPoint)value;
            writer.WriteValue(obj.ToString());
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) return Global.GetRandLocation();
            string st = (string)reader.Value;
            string[] values = st.Split(';');
            double.TryParse(values[1], out double difficulty);
            string[] valuesB = values[0].Split(':');
            Int64.TryParse(valuesB[0], out Int64 x);
            Int64.TryParse(valuesB[1], out Int64 y);
            return new WorldPoint(x, y, difficulty,values[1]);
        }
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(string);
        }
    }
}
