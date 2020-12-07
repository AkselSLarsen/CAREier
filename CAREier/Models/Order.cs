using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Localizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Models
{
    public class Order : IOrder 
    {
        private double _rating;
        private IBuyer _buyer;
        private IBringer _bringer;
        private IStore _store;
        private List<IProduct> _products;
        private LocalizedPrice _totalPrice;
        private static int _idCount;
        private int _OrderID;
        private DateTime _creationTime;

        public Order(IBuyer buyer) {
            _products = new List<IProduct>();
            _buyer = buyer;
            _OrderID = _idCount++;
        }

        public double Rating { get; set; }
        public IBuyer Buyer { get; }
        public IBringer Bringer { get { return _bringer; } set { _bringer = value; } }
        public IStore MyStore { get { return _store; } set { _store = value; } }
        public List<IProduct> Products { get { return _products; } set { _products = value; } }
        public LocalizedPrice TotalPrice { get { return _totalPrice; } set { _totalPrice = value; } }
        public int OrderID { get { return _OrderID; } set { _OrderID = value; } }
        public DateTime CreationDate { get { return _creationTime; } }
        public bool ITaken { get { return Bringer != null; } }

        public void AddToProductList(IProduct item)
        {
            _products.Add(item);
        }

        public void RemoveProductFromList(IProduct item)
        {
            _products.Remove(item);
        }
    }
}
