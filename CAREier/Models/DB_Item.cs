using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Models
{
   
    public abstract class DB_Item
    {
        public abstract string DataCatagory;
        public abstract List<string> MyData;
        private string id;
        public string DataID { get{ return id; } }
        /// <summary>
        /// abstract class for storing in DB
        /// </summary>
        /// <param name="id_type">Give A name to read back from the Jason file</param>
        public DB_Item(string data_catagory) {
            //Could make a tjeck here to insure no to id types are the same
            //By calling a statick class in helper class, but why not hard code this in? we not gonna change the data catagorys
            DataCatagory = data_catagory;
        }
        public void SetDB_ID(string id)
        {
            DataID = id;
        }
        public void AddData(params string[] data)
        {
            MyData.AddRange(data);
        }

    }
}
