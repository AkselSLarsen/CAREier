using Newtonsoft.Json;
using System;


namespace CAREier.Localizers {
    public class LocalizedWeight {
        private double _weight; //Weight in Kilograms

        public LocalizedWeight(double weight) {
            _weight = weight;
        }

        public LocalizedWeight()
        {
            _weight = 0;
        }
        public double WeightKilo {
            get { return _weight; }
            set { _weight = value; }
        }

        public double WeightPound {
            get { return _weight * 2.20462262d; }
            set { _weight = value / 2.20462262d; }
        }
        public override string ToString()
        {
            return _weight.ToString();
        }
    }
    public class WeightConverter : Newtonsoft.Json.JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            LocalizedWeight obj = (LocalizedWeight)value;

            writer.WriteValue(obj.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.Value == null) return new LocalizedWeight();
            LocalizedWeight obj = new LocalizedWeight(double.Parse((string)reader.Value));
            return obj;
        }
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(double);
        }

       
    }

    
}