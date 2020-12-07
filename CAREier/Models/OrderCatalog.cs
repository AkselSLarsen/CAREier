using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Localizers;
using Microsoft.AspNetCore.Mvc;

namespace CAREier.Models {
    public class OrderCatalog /*: ICRUD<Order>*/ {

        private string _filelocation;
        public void Create(Order item)
        {
            //throw new NotImplementedException();
        }

        public void Delete(Order item)
        {
            // throw new NotImplementedException();
        }

        public Order Read(int index)
        {
            return new Order();
            //throw new NotImplementedException();
        }

        public List<Order> ReadAll()
        {
            return new Order();
            // throw new NotImplementedException();
        }

        public void Update(Order item)
        {
            //throw new NotImplementedException();
        }
        /*

     

            public OrderCatalog(string filelocation)
            {
                _filelocation = filelocation;
            }

            private List<IOrder> _orders;

            public OrderCatalog()
            {
                _filelocation = @"Data\Products.json";

                _orders = new List<IOrder>();
                _orders.Add(new Order()
                {
                    /*Name = "milk",
                    Picture = "yes",
                    Price = new LocalizedPrice(20),
                    Weight = new LocalizedWeight(10),
                    Tags = new List<string>()

                }); 
                if (ReadState() != null) {
                    _orders.AddRange(ReadState());
                }
            }

            public void Create(IOrder item)
            {
                if (item != null)
                {
                    _orders.Add(item);
                    WriteState();
                }
            }

            public int Count()
            {
                return _orders.Count;
            }

            public IOrder Read(int index)
            {
                return _orders[index];
            }

            public IOrder ReadByName(string name)
            {
                foreach (var p in _orders)
                {
                    if (p.Name == name)
                    {
                        return p;
                    }
                }
                return new Order();
            }

            public List<IOrder> ReadAll()
            {
                return _orders.ToList();
            }

            public void Update(IOrder product)
            {
                if (product != null)
                {
                    foreach (var p in _orders)
                    {
                        if (p.Name == product.Name)
                        {
                            /*p.Name = product.Name;
                            p.Price = product.Price;
                            p.Weight = product.Weight;
                            p.Tags = product.Tags;
                            p.Picture = product.Picture;
                        }
                    }
                }
            }

        /*
        public void Delete(Order item) {
            if (item != null) {
                Order Temp = new Order();
                foreach (var v in _orders) {
                    if (item.Name == v.Name) {
                        Temp = v;
                    }
                }

                    WriteState();
                }

            }*/

        /*public IProduct Update(int index, IProduct item)
        {
            _products.RemoveAt(index);
            _products.Insert(index, item);

            WriteState();

            return _products[index];
        }

        }

        public Order Delete(int index) {
            Order deleted = Read(index);
            _orders.RemoveAt(index);

            WriteState();

            return deleted;
        }

        private List<Order> ReadState() {
            return ReadState(_filelocation);
        }

        private void WriteState() {
            WriteState(_orders, _filelocation);
        }
        }
        */

    }
}