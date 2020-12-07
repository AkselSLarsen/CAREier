using CAREier.Localizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces
{
    public interface IOrder
    {
        public double Rating { get; set; }
        public IBuyer Buyer { get; }
        public IBringer Bringer { get; set; }
        //Nu heder den MyStore, for det har jeg lyst til den skal hede! :D
        //Det er komplet uacceptablet!!! XD
        public IStore MyStore { get; }
        public List<IProduct> Products { get; }
        public LocalizedPrice TotalPrice { get; }
        public int OrderID { get; }
        public DateTime CreationDate { get; }
        
        public abstract void AddToProductList(IProduct item);
        public abstract void RemoveProductFromList(IProduct item);
    }
}
