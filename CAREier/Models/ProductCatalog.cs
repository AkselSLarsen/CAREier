using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Localizers;
using Microsoft.AspNetCore.Mvc;

namespace CAREier.Models
{
    public class ProductCatalog : JsonInterface<List<Product>, List<Product>>, ICRUD<Product>
    {
        private string _filelocation;
        private List<Product> _products;

        public ProductCatalog()
        {
            _filelocation = @"Data\Products.json";

            _products = new List<Product>();
            
            if (ReadState() != null) {
                _products.AddRange(ReadState());
            }
        }

        public void Create(Product item)
        {
            if (item != null)
            {
                foreach (var v in _products)
                {
                    if (item.Name == v.Name)
                    {
                        return;
                    }
                }
                _products.Add(item);
                WriteState();
            }
        }

        public Product Read(int index)
        {
            return _products[index];
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

                        WriteState();
                    }
                }
            }
        }


        public void Delete(Product item)
        {
            if (item != null)
            {
                Product Temp = new Product();
                foreach (var v in _products)
                {
                    if (item.Name == v.Name)
                    {
                        Temp = v;
                    }
                }

                if (Temp != null)
                { 
                    _products.Remove(Temp);
                    WriteState();
                }
                
            }

        }

        public Product Delete(int index)
        {
            Product deleted = Read(index);
            _products.RemoveAt(index);

            WriteState();

            return deleted;
        }

        public List<Store> FindStore(Product item)
        {
            foreach (var p in _products)
            {
                if (p.Stores != null)
                {
                    return p.Stores;
                }
                
            }
            return null;
        }

        private List<Product> ReadState() 
        {
            return ReadState(_filelocation);
        }

        private void WriteState() 
        {
            WriteState(_products, _filelocation);
        }
    }
}