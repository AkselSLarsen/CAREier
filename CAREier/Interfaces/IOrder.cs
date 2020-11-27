using CAREier.Localizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces
{
    public interface IOrder
    {
        public string Name { get; set; }

        //Nu heder den MyStore, for det har jeg lyst til den skal hede! :D
        public IStore MyStore { get; set; }
        public List<IProduct> Products { get; set; }
        public LocalizedPrice TotalPrice { get; set; }

        public string OrderID { get; set; }
        
        public abstract void AddProduct(IProduct item);
        public abstract void RemoveProduct(IProduct item);
    }
}
