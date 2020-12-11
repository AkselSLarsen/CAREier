using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace CAREier {
    public class TagSystem {

        
        private string[] _tags;

        public TagSystem()
        {
            _tags = new string[1] { "All" };
        }
        public TagSystem(string tags)
        {
            _tags = StringToTags(tags);
        }
        public string[] StringToTags(string s) {
            return s.Split(",");
        }
        /// <summary>
        /// Makes sure all tags are unicure
        /// </summary>
        /// <param name="newtags"></param>
        public void Add(params string[] newtags)
        {
            List<string> newTagsList = _tags.ToList();
            foreach (string t in newtags)
            {
                foreach (string tag in _tags)
                {
                    if (tag == t) continue;
                    newTagsList.Add(t);
                }
            }
            _tags = newTagsList.ToArray();
        }
      
        public void Remove(string[] findtags)
        {
            List<string> newTagsList = new List<string>();
            foreach (string t in findtags)
            {
                foreach (string tag in _tags)
                {
                    if (tag == t) continue;
                    newTagsList.Add(tag);
                }
            }
            _tags = newTagsList.ToArray();
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
        public override string ToString()
        {
            string re = "";
            for (int i = 0; i < _tags.Length; i++)
            {
                if (i != _tags.Length - 1)
                {
                    re += _tags[i] + ", ";
                }
                else
                {
                    re += _tags[i];
                }
            }
            return re;
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
