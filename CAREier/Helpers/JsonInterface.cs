using CAREier.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Helpers {
    /// <summary>
    /// An abstact class that allows writing and reading of data to and from Json files.
    /// The class requires that you give it both at type to read and a type to write.
    /// These may be different or identical, but must be explicitly written out.
    /// </summary>
    /// <typeparam name="ReadItem">The type of the objects you want to get out of the .Json file</typeparam>
    /// <typeparam name="WriteItem">The type of the objects you want to write to the .Json file</typeparam>
    public abstract class JsonInterface<ReadItem, WriteItem> : IReader<ReadItem>, IWriter<WriteItem> {

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