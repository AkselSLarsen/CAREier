using CAREier.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Helpers {
    public class JsonFileSystem {
        public string filePath;
        public List<DB_Item> ItemQueue;
        public JsonFileSystem (string filePath)
        {
            this.filePath = filePath;
            ItemQueue = new List<DB_Item>();
        }
        public List<DB_Item> Read()
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<DB_Item>>(jsonString);
        }
        /// <summary>
        /// Read from a Custom filepath
        /// </summary>
        /// <param name="JsonFileName"></param>
        /// <returns></returns>
        public List<DB_Item> Read(string JsonFileName) {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<List<DB_Item>>(jsonString);
        }
        public void Write()
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(ItemQueue, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(filePath, output);
            ItemQueue.Clear();
        }
        public void Write(List<DB_Item> products)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(products, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(filePath, output);

        }
        /// <summary>
        /// Save to a Custom filepath
        /// </summary>
        /// <param name="products"></param>
        /// <param name="JsonFileName"></param>
        public void Write(List<DB_Item> products, string JsonFileName) {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(products, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }
    }
}
