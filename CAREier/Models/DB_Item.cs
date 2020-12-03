using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Models
{
    public abstract class DB_Item
    {
        public string Name;
        public string ItmeType;
        public Dictionary<string, object> my_values;
        public DB_Item(string name)
        {
            Name = name;
            my_values = new Dictionary<string, object>();
        }
        public abstract void save();
        public abstract void load();
    }
}
