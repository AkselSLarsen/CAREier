using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Localizers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace CAREier.Models
{
    public class ProductCatalog : ICRUD<Product>
    {
        private string _filelocation;
        private List<Product> _products;
        private int counter;

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
                    if (p.id == product.id)
                    {
                        p.Name = product.Name;
                        p.Price = product.Price;
                        p.Weight = product.Weight;
                        p.Tags = product.Tags;
                        p.Picture = product.Picture;
                        p.id = product.id;
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
                    if (item.id == v.id)
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

      
        private List<Product> ReadState() 
        {
            return JsonFileSystem.ReadProduct(_filelocation);
        }

        private void WriteState() 
        {
            JsonFileSystem.WriteProduct(_products, _filelocation);
        }
    }
}