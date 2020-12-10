﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CAREier.Interfaces;
using CAREier.Localizers;

namespace CAREier.Models
{
    public class Product : IProduct
    {
        private string _name;
        private LocalizedPrice _price;
        private LocalizedWeight _weight;
        private List<string> _tags;
        private List<Store> _stores;
        private int _id;
        private List<string> _ShopIDList;

        //[Required(AllowEmptyStrings = false, ErrorMessage = "the product must have a name")]
        public Product()
        {
            _ShopIDList = new List<string>();
        }


        public string Name
        {
            get { return _name;}
            set { _name = value; }
        }

        public List<Store> Stores
        {
            get { return _stores; }
            set { _stores = value; }
        }

        //[Required] [Range(0, 1000000)]
        public LocalizedPrice Price
        {
            get { return _price; }
            set { _price = value; }
        }

        //[Required] [Range(0, 1000000)]
        public LocalizedWeight Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public string Picture { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "the product must have at least 1 tag")]
        public List<string> Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }
       
        public List<string> ShopIDList
        {
            get { return _tags; }
            set { _tags = value; }
        }
        public List<string> BindToShop(string ShopID)
        {
            ShopIDList.Add(ShopID);
        }
        /*public Product(string name, LocalizedPrice price, LocalizedWeight weight,
            List<string> tags)
        {
            _name = name;
            _price = price;
            _weight = weight;
            _tags = tags;
        }*/

        /*public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                Product pind = (Product)obj;
                if (pind.Name == Name )
                    return true;
            }
            return false;
        }*/
    }
}