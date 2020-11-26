using System;
using System.Collections.Generic;
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

        public string Name { get; set; }
        public LocalizedPrice Price { get; set; }
        public LocalizedWeight Weight { get; set;  }
        public LocalizedDimensions Dimensions { get; set; }
        public List<string> Tags { get; set; }

        public Product(string name, double price, double weight, Vector3 dimensions,
            List<string> tags)
        {
            _name = name;
            _price.PriceDKK = price;
            _weight.WeightKilo = weight;
            _dimensions.DimensionsInCM = dimensions;
            _tags = tags;
        }
    }
}
