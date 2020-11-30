using System;
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

        [Required(AllowEmptyStrings = false, ErrorMessage = "the product must have a name")]
        public string Name
        {
            get { return _name;}
            set { _name = value; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "the product must have a price")]
        public LocalizedPrice Price
        {
            get { return _price; }
            set { _price = value; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "the product must have a weight")]
        public LocalizedWeight Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public string Picture { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "the product must have at least 1 tag")]
        public List<string> Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }

        public Product(string name, double price, double weight,
            List<string> tags)
        {
            _name = name;
            _price = new LocalizedPrice(price);
            _weight = new LocalizedWeight(weight);
            _tags = tags;
        }
    }
}