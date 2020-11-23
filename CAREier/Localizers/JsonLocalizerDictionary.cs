using CAREier.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Localizers {
    public class JsonLocalizerDictionary : ILocalizer, IReader<Dictionary<string, string>>, IWriter<Dictionary<string, string>> {
        private Dictionary<string, string> _translations;
        private string fileLocation;

        public JsonLocalizerDictionary(string fileLocation) {
            _translations = new Dictionary<string, string>();
            this.fileLocation = fileLocation;

            ReadState(fileLocation);
        }

        public string GetLocalizedString(string s) {
            if(_translations.ContainsKey(s)) {
                return _translations[s];
            }
            setLocalizedString(s, s);
            return s;
        }

        public void setLocalizedString(string unlocalizedString, string localizedString) {
            _translations.Add(unlocalizedString, localizedString);
            WriteState(_translations, fileLocation);
        }

        public Dictionary<string, string> ReadState(string fileLocation) {
            string jsonString = File.ReadAllText(fileLocation);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
        }

        public void WriteState(Dictionary<string, string> state, string fileLocation) {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(state, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(fileLocation, output);
        }
    }
}