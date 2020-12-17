using CAREier.Helpers;
using CAREier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces
{
    public interface ICatalog<Item>
    {

        public void Create(Item item);

        public Item Read(int index);
        public List<Item> ReadAll();

        public void Update(Item product);
        public void Delete(Item item);
        public int Length();
        public int Index(Item item);
        public Item GetByName(string name);
    }
}
