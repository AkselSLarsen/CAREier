using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Localizers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Models
{
    public class Order 
    {
        private double _rating;
        private Buyer _buyer;
        private Bringer _bringer;
        private Store _store;
        public List<Product> Products;
        public Dictionary<int, int> ProductCount;
        

       
        
        private static int _idCount;
        private int _OrderID;
        private DateTime _creationTime;

        public Order(Buyer buyer, Store FromStore) {
            Products = new List<Product>();
            _buyer = buyer;
            _store = FromStore;
            _OrderID = _idCount++;
            _creationTime = DateTime.Now;
            ProductCount = new Dictionary<int, int>();
        }
        public Order(int id, string date, string buyerEmail, string StoreAdress,string bringerEmail)
        {
            Products = new List<Product>();
            _buyer = new Buyer();
            _buyer.Email = buyerEmail;
            _store = new Store();
            _store.Adress = StoreAdress;
            _bringer = new Bringer();
            _bringer.Email = bringerEmail;
            _OrderID = id;
            _creationTime = DateTime.Parse(date);
            ProductCount = new Dictionary<int, int>();
        }

        public double Rating { get; set; }

        //[JsonConverter(typeof(PriceConverter))]

        // [JsonConverter(typeof(WeightConverter))]
        // public LocalizedWeight TotalWeight { get { return _totalWeight; } private set { _totalWeight = value; } }
        public int OrderID { get { return _OrderID; } set { _OrderID = value; } }
        public DateTime CreationDate { get { return _creationTime; } }
        public bool ITaken { get { return Bringer != null; } }
        
        public string Buyer_name { get { return _buyer.Email; } }
        public string Store_name { get { return _store.Adress; } }
        public string Bringer_name { get { return _bringer.Email; } }
        //[JsonIgnore]
        // [JsonConverter(typeof(ProductListConverter))]
        [JsonIgnore]
        public double TotalPrice
        {
            get
            {
                double value = 0;
                foreach (var p in Products)
                {
                    value += p.Price.PriceDKK;
                }
                return value;
            }
        }
        [JsonIgnore]
        public double TotalWeight
        {
            get
            {
                double value = 0;
                foreach (var p in Products)
                {
                    value += p.Weight.WeightKilo;
                }
                return value;
            }
        }
        [JsonIgnore]
        public Buyer Buyer { get; }
        [JsonIgnore]
        public Bringer Bringer { get { return _bringer; } set { _bringer = value; } }
        [JsonIgnore]
        public Store MyStore { get { return _store; } set { _store = value; } }
    
        public int CountProds()
        {
            int val = 0;
            foreach (Product item in Products)
            {
                val += ProductCount[item.id];
            }
            return val;
        }

    }

}