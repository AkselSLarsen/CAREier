using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Interfaces;
using CAREier.Localizers;

namespace CAREier.Models
{
    public class ProdInfo : IProduct
    {
        private string _info;
        public string Name {
            get { return _info; }
        }
        public LocalizedPrice Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public LocalizedWeight Weight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TagSystem Tags { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Picture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Store> Stores { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ProdInfo(string info) {
            _info = info;

        }
    }
}
