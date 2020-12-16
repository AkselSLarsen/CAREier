using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces {
    [Obsolete]
    public interface ITranslator {

        public string GetTranslatedString(string s);
        public void SetTranslatedString(string unlocalizedString, string localizedString);

    }
}