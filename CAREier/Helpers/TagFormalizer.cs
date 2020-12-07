using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Helpers {
    public static class TagFormalizer {

        public static string TagsToString(List<string> tags) {
            string re = "";
            for(int i=0; i<tags.Count; i++) {
                if (i != tags.Count - 1) {
                    re += tags[i] + ", ";
                } else {
                    re += tags[i];
                }
            }
            return re;
        }

        public static List<string> StringToTags(string s) {
            List<string> re = new List<string>();
            string[] strs = s.Split(", ");
            foreach(string str in strs) {
                re.Add(str);
            }
            return re;
        }
    }
}
