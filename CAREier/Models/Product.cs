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
        private LocalizedDimensions _dimensions;
        private List<string> _tags;

        [Required(AllowEmptyStrings = false, ErrorMessage = "the product must have a name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "the product must have a price")]
        public LocalizedPrice Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "the product must have a weight")]
        public LocalizedWeight Weight { get; set;  }

        [Required(AllowEmptyStrings = false, ErrorMessage = "the product must have dimensions")]
        public LocalizedDimensions Dimensions { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "the product must have at least 1 tag")]
        public List<string> Tags { get; set; }
        

        public Product(string name, double price, double weight, Vector3 dimensions,List<string> tags)
        {
            _name = name;
            _price.PriceDKK = price;
            _weight.WeightKilo = weight;
            _dimensions.DimensionsInCM = dimensions;
            _tags = tags;
        }
    }
}
