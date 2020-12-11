using CAREier.Localizers;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CAREier.Models;

namespace CAREier.Interfaces {
    public interface IProduct {

        public string Name { get; set; }
        public LocalizedPrice Price { get; set; }
        public LocalizedWeight Weight { get; set; }
        public TagSystem Tags { get; set; }
        public string Picture { get; set; }

        public List<Store> Stores { get; set; }
    }
}