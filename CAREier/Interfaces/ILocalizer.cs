using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces {
    interface ILocalizer {

        public string GetLocalizedString(string s);
        public void setLocalizedString(string unlocalizedString, string localizedString);

    }
}
