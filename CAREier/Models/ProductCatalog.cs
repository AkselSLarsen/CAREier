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
        private List<IProduct> _products;

        public ProductCatalog()
        {
            products = new List<IProduct>();
        }


        public List<IProduct> GetAllProducts()
        {
            return products.ToList();
        }
        public void Create(IProduct item)
        {
            if (item != null)
            {
                products.Add(item);
            }
        }

        public IProduct Read(int index)
        {
            return products[index];
        }

        public IProduct Update(IProduct pre, IProduct post)
        {
            if (pre != null || post != null)
            {
                if (products.Contains(pre))
                {
                    pre = post;
                    return post;
                }
            }

            return null;
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

        public void Delete(int index)
        {
            products.RemoveAt(index);
        }
    }
}