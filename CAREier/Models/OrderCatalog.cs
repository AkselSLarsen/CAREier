using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Localizers;

namespace CAREier.Models
{
    public class OrderCatalog : List<IOrder>, IHandler<IOrder>
    {
        private string _filelocation;
        private List<IOrder> _orders;

        public OrderCatalog()
        {
            _filelocation = @"Data\Products.json";

            _orders = new List<IOrder>();
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

        public int Lengt()
        {
            return _orders.Count;
        }

        public IOrder Read(int index)
        {
            return _orders[index];
        }

        public List<IOrder> ReadAll()
        {
            return _orders.ToList();
        }

        void IHandler<IOrder>.Update(IOrder pre, IOrder post)
        {
            if (_orders.Contains(pre) )
            {
                int deleted = _orders.IndexOf(pre);
                _orders.Remove(pre);
                _orders.Insert(deleted, post);

                WriteState();
            }
            
        }

        public IOrder Update(int index, IOrder item)
        {
            _orders.RemoveAt(index);
            _orders.Insert(index, item);

            WriteState();

            return _orders[index];
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

        private List<IOrder> ReadState()
        {
            return JsonInterface<List<IOrder>, List<IOrder>>.ReadState(_filelocation);
        }
        private void WriteState()
        {
            JsonInterface<List<IOrder>, List<IOrder>>.WriteState(_orders, _filelocation);
        }
    }
}