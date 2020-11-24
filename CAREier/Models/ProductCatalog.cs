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

        public ProductCatalog(List<IProduct> products)
        {
            _products = new List<IProduct>();
            products.Add(new Product("milk", 20, 1, new Vector3(1, 1, 1), new List<string>() ));
        }

        public List<IProduct> Products
        {
            get { return _products;}
        }
        public void Create(IProduct item)
        {
            if (item != null)
            {
                Products.Add(item);
            }
        }

        public IProduct Read(int index)
        {
            return Products[index];
        }

        public IProduct Update(IProduct pre, IProduct post)
        {
            if (pre != null || post != null)
            {
                if (Products.Contains(pre))
                {
                    pre = post;
                    return post;
                }
            }

            return null;
        }

        public IProduct Update(int index, IProduct item)
        {
            Products.RemoveAt(index);
            Products.Insert(index, item);
            return Products[index];
        }

        public void Delete(IProduct item)
        {
            Products.
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }
    }
}
