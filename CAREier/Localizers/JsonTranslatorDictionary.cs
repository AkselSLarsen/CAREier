using CAREier.Helpers;
using CAREier.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Localizers {
    [Obsolete]
    public class JsonTranslatorDictionary : JsonInterface<Dictionary<string, string>, Dictionary<string, string>>, ITranslator {
        private Dictionary<string, string> _translations;
        private string _fileLocation;

        public JsonTranslatorDictionary(string fileLocation) {
            _translations = new Dictionary<string, string>();
            this._fileLocation = fileLocation;

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
    }
}