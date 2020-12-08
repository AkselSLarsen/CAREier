using CAREier.Localizers;
using CAREier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces
{
    public interface IOrder
    {
        public double Rating { get; set; }
        public Buyer Buyer { get; }
        public Bringer Bringer { get; set; }
        //Nu heder den MyStore, for det har jeg lyst til den skal hede! :D
        //Det er komplet uacceptablet!!! XD
        public Store MyStore { get; }
        public List<IProduct> Products { get; }
        public LocalizedPrice TotalPrice { get; }
        public LocalizedWeight TotalWeight { get; }
        public int OrderID { get; }
        public DateTime CreationDate { get; }
        
        public abstract void AddToProductList(IProduct item);
        public abstract void RemoveProductFromList(IProduct item);
    }
}
