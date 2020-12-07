using CAREier.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Helpers {
    public static class JsonFileSystem {
        //Read and Write Products
        public static List<Product> ReadProduct(string JsonFileName) {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<List<Product>>(jsonString);
        }
        public static void WriteProduct(List<Product> products, string JsonFileName) {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(products, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }

        public static List<Order> ReadOrder(string JsonFileName) {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<List<Order>>(jsonString);
        }
        public static void WriteOrder(List<Order> orders, string JsonFileName) {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(orders, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }
    }
}