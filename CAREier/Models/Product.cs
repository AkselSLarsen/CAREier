﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CAREier.Interfaces;
using CAREier.Localizers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CAREier.Models
{
    public class Product : IProduct
    {
        private string _name;
        private LocalizedPrice _price;
        private LocalizedWeight _weight;
        private TagSystem _tags;
        private Store _store;
        private int _id;

        //[Required(AllowEmptyStrings = false, ErrorMessage = "the product must have a name")]
        public Product()
        {
            Tags = new TagSystem();
     
        }
        public Product(string name, LocalizedPrice price, LocalizedWeight weight, TagSystem tags, int id) {
            Tags = new TagSystem();

            _name = name;
            _price = price;
            _weight = weight;
            _tags = tags;
            _id = id;
        }

        public string Name
        {
            get { return _name;}
            set { _name = value; }
        }
        //[JsonIgnore]
       /* public string Store_info
        {
            get { return Store.LookUpInfo(); }
        }*/
        
        public Store Store
        {
            get { return _store; }
            set { 
                _store = value; 
            }
        }

        //[Required] [Range(0, 1000000)]
        [JsonConverter(typeof(PriceConverter))]
        public LocalizedPrice Price
        {
            get { return _price; }
            set { _price = value; }
        }

        //[Required] [Range(0, 1000000)]
        [JsonConverter(typeof(WeightConverter))]
        public LocalizedWeight Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public string Picture { get; set; }

       /* public bool HasStore(Store myStore)
        {
            if (_stores == null) return false;
            foreach (Store str in _stores)
            {
                if (str.Location.UnicID(str.Email) == myStore.Location.UnicID(myStore.Email)) return true;
            }
            return false;
        }
        */
        //[Required(AllowEmptyStrings = false, ErrorMessage = "the product must have at least 1 tag")]
        /// <summary>
        /// Is Read only, User .TagAdd( [Item] ) to add tags
        /// </summary>
        [JsonConverter(typeof(TagConverter))]
        public TagSystem Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string LookUpInfo()
        {
            return $"{_name},{Tags.ToString()},{_id}";
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