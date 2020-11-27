using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces
{
    public interface IOrder
    {
        public string Name { get; set; }

        public IStore Store { get; set; }
        public List<IProduct> Products { get; set; }
        public float TotalPrice { get; set; }

        public int ORDERID { get; set; }
        
        public abstract void AddProduct(IProduct item);
        public abstract void RemoveProduct(IProduct item);
    }
}
