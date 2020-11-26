using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CAREier.Interfaces;
using CAREier.Localizers;

namespace CAREier.Models
{
    public class ProductCatalog : IHandler<IProduct>
    {
        private List<IProduct> products;

        public ProductCatalog()
        { 
            products = new List<IProduct>();
            products.Add(new Product("milk", 1, 2, new Vector3(1, 2, 3), new List<string>()));

        }



        public void Create(IProduct item)
        {
            if (item != null)
            {
                products.Add(item);
            }
        }

        public int Count()
        {
            return products.Count;
        }

        public IProduct Read(int index)
        {
            return products[index];
        }

        public List<IProduct> ReadAll()
        {
            return products.ToList();
        }

        void IHandler<IProduct>.Update(IProduct pre, IProduct post)
        {
            if (products.Contains(pre) )
            {
                int deleted = products.IndexOf(pre);
                products.Remove(pre);
                products.Insert(deleted, post);
            }
            
        }


        public IProduct Update(int index, IProduct item)
        {
            products.RemoveAt(index);
            products.Insert(index, item);
            return products[index];
        }

        public void Delete(IProduct item)
        {
            products.Remove(item);
        }

        IProduct IHandler<IProduct>.Delete(int index)
        {
            IProduct deleted = Read(index);
            products.RemoveAt(index);
            return deleted;
        }
    }
}