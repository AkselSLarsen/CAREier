using CAREier.Interfaces;
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

        //Read and Write Orders
        public static List<Order> ReadOrder(string JsonFileName) {
            string jsonString = File.ReadAllText(JsonFileName);

            return JsonConvert.DeserializeObject<List<Order>>(jsonString);
        }
        public static void WriteOrder(List<Order> orders, string JsonFileName) {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(orders, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }

        public static List<Buyer> ReadBuyers(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<List<Buyer>>(jsonString);
        }
        public static void WriteBuyers(List<Buyer> buyers, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(buyers, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }

        public static List<Store> ReadStores(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<List<Store>>(jsonString);
        }
        public static void WriteStores(List<Store> stores, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(stores, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }
        public static List<Bringer> ReadBringers(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<List<Bringer>>(jsonString);
        }
        public static void WriteBringers(List<Bringer> bringers, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(bringers, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }
    }
}