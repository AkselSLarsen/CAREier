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

        public void Delete(Item item);

        public void Update(Item product);

        public void Read(int index);
        public void Save();
        public List<Item> Load();
        public int Length();

        public int Index(Item item);
        public Item GetByName(string name);

        public List<Item> ReadAll();
    }
}
