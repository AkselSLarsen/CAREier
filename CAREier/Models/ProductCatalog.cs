﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Localizers;

namespace CAREier.Models
{
    public class ProductCatalog : JsonInterface<List<Product>, List<Product>>, IHandler<Product>
    {
        private string _filelocation;
        private List<Product> _products;

        public ProductCatalog()
        {
            _filelocation = @"Data\Products.json";

            _products = new List<Product>();
            _products.Add(new Product()
            {
                Name = "milk",
                Picture = "yes",
                Price = new LocalizedPrice(20),
                Tags = new List<string>(),
                Weight = new LocalizedWeight(10)
            }); 
            if (ReadState() != null) {
                _products.AddRange(ReadState());
            }
        }

        public void Create(Product item)
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

        public Product Read(int index)
        {
            return _products[index];
        }

        public Product ReadByName(string name)
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

        public List<Product> ReadAll()
        {
            return _products.ToList();
        }

        public void Update(Product product)
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

        public void Delete(Product item)
        {
            _products.Remove(item);

            WriteState();
        }

        public Product Delete(int index)
        {
            Product deleted = Read(index);
            _products.RemoveAt(index);

            WriteState();

            return deleted;
        }

        private List<Product> ReadState() {
            return ReadState(_filelocation);
        }

        private void WriteState() {
            WriteState(_products, _filelocation);
        }
    }
}