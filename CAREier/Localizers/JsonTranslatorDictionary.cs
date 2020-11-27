using CAREier.Helpers;
using CAREier.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Localizers {
    public class JsonTranslatorDictionary : ITranslator, IReader<Dictionary<string, string>>, IWriter<Dictionary<string, string>> {
        private Dictionary<string, string> _translations;
        private string _fileLocation;
        private JsonInterface<Dictionary<string, string>> _interface;

        public JsonTranslatorDictionary(string fileLocation) {
            _translations = new Dictionary<string, string>();
            this._fileLocation = fileLocation;

            _interface = new JsonInterface<Dictionary<string, string>>();

            ReadState(fileLocation);
        }

        public string GetTranslatedString(string s) {
            if(_translations.ContainsKey(s)) {
                return _translations[s];
            }
            SetTranslatedString(s, s);
            return s;
        }

        public void SetTranslatedString(string unlocalizedString, string localizedString) {
            _translations.Add(unlocalizedString, localizedString);
            WriteState(_translations, _fileLocation);
        }

        public Dictionary<string, string> ReadState(string fileLocation) {
            return _interface.ReadState(fileLocation);
        }

        public void WriteState(Dictionary<string, string> state, string fileLocation) {
            _interface.WriteState(state, fileLocation);
        }
    }
}