using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace CAREier {
    public class TagSystem {

        
        private string[] _tags;

        public string body
        {
            get { return ToString(); }
            set { _tags = StringToTags(value); }
        }

        public TagSystem()
        {
            _tags = new string[1] { "All" };
        }
        public TagSystem(string tags)
        {
            
            _tags = StringToTags(tags);
        }
        public string[] StringToTags(string s) {
            //Remove unvonted symbols
            string Tstr = s.Replace(';', ',');
            Tstr = Tstr.Replace(':', ',');
            string[] st = Tstr.Split(",");
            //To avoid null tags and white space
            List<string> newTagsList = new List<string>();
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i].Trim().Length > 0) newTagsList.Add(st[i]);
            }
            return newTagsList.ToArray();
        }
        /// <summary>
        /// Makes sure all tags are unicure
        /// </summary>
        /// <param name="newtags"></param>
        public void Add(params string[] newtags)
        {
            string newStr = ListToString(_tags);
            foreach (string Newt in newtags)
            {
                if (!find(_tags,Newt)) newStr += Newt;
            }
            _tags = StringToTags(newStr);
        }
        
        public void Remove(params string[] findtags)
        {
            string newStr = "All,";
            foreach (string tag in _tags)
            {
                if (find(findtags, tag)) continue; 
                newStr += tag;
            }
            _tags = StringToTags(newStr);
        }
        public bool find(string[] list, string findtag)
        {
            foreach (string currenttag in list)
            {
                if (currenttag == findtag) return true;
            }
            return false;
        }
        public bool Contains(params string[] findTags)
        {
            int hasTags = 0;
            for (int i = 0; i < findTags.Length; i++)
            {
                foreach (string t in _tags)
                {
                    if (findTags[i] == t)
                    {
                        hasTags++;
                        break;

                    }
                }
            }
            //if hasTags is > its clearly a mistake, but product sould stil be in cluded
            //as it has all the tags
            return hasTags >= findTags.Length;
        }
        public string ListToString(string[] taglist)
        {
            string re = "";
            for (int i = 0; i < taglist.Length; i++)
            {
                if (i != taglist.Length - 1)
                {
                    re += taglist[i] + ",";
                }
                else
                {
                    re += taglist[i];
                }
            }
            return re;
        }
        public override string ToString()
        {
 
            return ListToString(_tags);
        }
    }
    public class TagConverter : Newtonsoft.Json.JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            TagSystem obj = (TagSystem)value;

            writer.WriteValue(obj.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) return new TagSystem();
            TagSystem obj = new TagSystem((string)reader.Value);
            return obj;
        }
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(string);
        }
    }
}