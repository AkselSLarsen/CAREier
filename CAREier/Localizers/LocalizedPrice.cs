using Newtonsoft.Json;
using System;

namespace CAREier.Localizers {
    public class LocalizedPrice {
        private double _price; //Price in Euro

        public LocalizedPrice(double price) {
            _price = price;
        }

        public LocalizedPrice()
        {
            _price = 0;
        }

        public double PriceDKK {
            get { return _price * 7.5; }
            set { _price = value / 7.5; }
        }

        public double PriceEuro {
            get { return _price; }
            set { _price = value; }
        }
        public override string ToString()
        {
            return _price.ToString();
        }

    }
    public class PriceConverter : Newtonsoft.Json.JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            LocalizedPrice obj = (LocalizedPrice)value;

            writer.WriteValue(obj.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) return new LocalizedPrice();
            LocalizedPrice obj = new LocalizedPrice(double.Parse((string)reader.Value));
            return obj;
        }
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(double);
        }
    }
}