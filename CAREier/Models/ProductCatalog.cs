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
    public class ProductCatalog : JsonInterface<List<IProduct>>, IHandler<IProduct>
    {
        private string _filelocation;
        private List<IProduct> _products;

        public ProductCatalog()
        {
            _filelocation = @"Data\Products.json";

            _products = ReadState();
        }

        public void Create(IProduct item)
        {
            if (item != null)
            {
                _products.Add(item);
                WriteState();
            }
        }

        public int Count()
        {
            return _products.Count;
        }

        public IProduct Read(int index)
        {
            return _products[index];
        }

        public IProduct ReadByName(string name)
        {
            foreach (var p in _products)
            {
                if (p.Name == name)
                {
                    return p;
                }
            }
            return new Product();
        }

        public List<IProduct> ReadAll()
        {
            return _products.ToList();
        }

        public void Update(IProduct product)
        {
            if (product != null)
            {
                foreach (var p in _products)
                {
                    if (p.Name == product.Name)
                    {
                        p.Name = product.Name;
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
        }*/

        public void Delete(IProduct item)
        {
            _products.Remove(item);

            WriteState();
        }

        IProduct IHandler<IProduct>.Delete(int index)
        {
            IProduct deleted = Read(index);
            _products.RemoveAt(index);

            WriteState();

            return deleted;
        }

        private List<IProduct> ReadState() {
            return ReadState(_filelocation);
        }

        private void WriteState() {
            WriteState(_products, _filelocation);
        }
    }
}