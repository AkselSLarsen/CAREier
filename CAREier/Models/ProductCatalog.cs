using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Interfaces;

namespace CAREier.Models
{
    public class ProductCatalog : IHandler<IProduct>
    {
        public void Create(IProduct item)
        {
            throw new NotImplementedException();
        }

        public IProduct Read()
        {
            throw new NotImplementedException();
        }

        public IProduct Update(IProduct pre, IProduct post)
        {
            throw new NotImplementedException();
        }

        public void Delete(IProduct item)
        {
            throw new NotImplementedException();
        }
    }
}
