using CAREier.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Helpers {
    public class JsonInterface<Item> : IReader<Item>, IWriter<Item> {

        public JsonInterface() {

        }

        public Item ReadState(string fileLocation) {
            string jsonString = File.ReadAllText(fileLocation);
            return JsonConvert.DeserializeObject<Item>(jsonString);
        }

        public void WriteState(Item state, string fileLocation) {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(state, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(fileLocation, output);
        }
    }
}
