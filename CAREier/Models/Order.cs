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
        private List<string> _products;
       
        private LocalizedPrice _totalPrice;
       
        private LocalizedWeight _totalWeight;
        private static int _idCount;
        private int _OrderID;
        private DateTime _creationTime;

        public Order(Buyer buyer, Store FromStore) {
            _products = new List<string>();
            _buyer = buyer;
            _store = FromStore;
            _OrderID = _idCount++;
            _creationTime = DateTime.Now;
        }
       

        public double Rating { get; set; }
      
        [JsonConverter(typeof(PriceConverter))]
        public LocalizedPrice TotalPrice { get { return _totalPrice; } private set { _totalPrice = value; } }
        [JsonConverter(typeof(WeightConverter))]
        public LocalizedWeight TotalWeight { get { return _totalWeight; } private set { _totalWeight = value; } }
        public int OrderID { get { return _OrderID; } set { _OrderID = value; } }
        public DateTime CreationDate { get { return _creationTime; } }
        public bool ITaken { get { return Bringer != null; } }
        //[JsonIgnore]
        // [JsonConverter(typeof(ProductListConverter))]
        [JsonIgnore]
        public Buyer Buyer { get; }
        [JsonIgnore]
        public Bringer Bringer { get { return _bringer; } set { _bringer = value; } }
        [JsonIgnore]
        public Store MyStore { get { return _store; } set { _store = value; } }
        public void AddToProductList(string info)
        {
            _products.Add(info);
        }

        public void RemoveProductFromList(string item)
        {
            _products.Remove(info);
        }
    }
    
}