using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Localizers;
/*
namespace CAREier.Models
{
    public class OrderCatalog : JsonInterface<List<IOrder>, List<IOrder>>, IHandler<IOrder>
    {
        private string _filelocation;

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

        /*void IHandler<IProduct>.Update(IProduct pre, IProduct post)
        {
            if (_products.Contains(pre) )
            {
                int deleted = _products.IndexOf(pre);
                _products.Remove(pre);
                _products.Insert(deleted, post);

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

        public void Delete(IOrder item)
        {
            _orders.Remove(item);

            WriteState();
        }

        IOrder IHandler<IOrder>.Delete(int index)
        {
            IOrder deleted = Read(index);
            _orders.RemoveAt(index);

            WriteState();

            return deleted;
        }

        private List<IOrder> ReadState() {
            return ReadState(_filelocation);
        }

        private void WriteState() {
            WriteState(_orders, _filelocation);
        }

        IOrder IHandler<IOrder>.ReadByName(string name)
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
    }
}*/