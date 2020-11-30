using CAREier.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Helpers {
    public abstract class JsonInterface<ReadItem, WriteItem> : IReader<ReadItem>, IWriter<WriteItem> {

        public JsonInterface() {

        }

        public ReadItem ReadState(string fileLocation) {
            string jsonString = File.ReadAllText(fileLocation);
            return JsonConvert.DeserializeObject<ReadItem>(jsonString);
        }

        public void WriteState(WriteItem state, string fileLocation) {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(state, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(fileLocation, output);
        }
    }
}