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
        private int _maxId;

        public ProductCatalog()
        {
            _filelocation = @"Data\Products.json";

            _products = new List<Product>();
            
            if (ReadState() != null) {
                _products.AddRange(ReadState());
            }
            _maxId = 0;
            calculateMaxId(false);
        }

        public void Create(Product item)
        {
            if (item != null)
            {
                item.id = ++_maxId; // this is shorthand for "maxId = maxId + 1; item.id = _maxId;"
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
                    
                    if(item.id == _maxId) {
                        calculateMaxId(true);
                    }
                }
                
            }

        }

        public Product Delete(int index)
        {
            Product deleted = Read(index);
            Delete(deleted);

            return deleted;
        }

        /// <summary>
        /// This method ensures that every product not only gets a unique id amoungst existing products, but also amoungst no longer existing products.
        /// This is achieved by always keeping track of the largest Id amoungst the current products, and giving new products higher Ids than that.
        /// This itself ensures it in all but one edge case, which is if the current product with the highest Id is deleted.
        /// This is remidied by checking for that edge case, and then reasigning the current product with the smallest Id, a new Id larger than the former max.
        /// </summary>
        /// <param name="wasRemoved">If the product with the highst Id was just deleted</param>
        private void calculateMaxId(bool maxWasRemoved) {
            if (maxWasRemoved) {
                int minId = int.MaxValue;
                Product temp = null;
                foreach (Product product in _products) {
                    if (product.id < minId) {
                        minId = product.id;
                        temp = product;
                    }
                }
                Delete(temp);
                temp.id = ++_maxId; // this is shorthand for "maxId = maxId + 1; temp.id = _maxId;", though is it really shorthand if I have to write all this out just to explain it?!?
                Create(temp);
                WriteState();
            } else {
                foreach (Product product in _products) {
                    if (product.id > _maxId) {
                        _maxId = product.id;
                    }
                }
            }
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