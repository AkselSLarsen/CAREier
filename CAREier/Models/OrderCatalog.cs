using CAREier.Helpers;
using CAREier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Models
{
    public class OrderCatalog : FileCatalog, ICatalog<Order>
    {
        public OrderCatalog(JsonFileSystem jsonfileSaver) : base(jsonfileSaver)
        {
          
        }
        public void Create(Order item)
        {
            Create(item);
        }

        public void Delete(Order item)
        {
            Create(item);
        }

        public DB_Item GetByName(string name)
        {
            GetByName(name);
        }

        public int Index(DB_Item item)
        {
            
        }

        public int Length()
        {
            
        }

        public List<DB_Item> Load()
        {
            
        }

        public void Read(int index)
        {
            
        }

        public List<DB_Item> ReadAll()
        {
           
        }

        public void Save()
        {
           
        }

        public void Update(DB_Item product)
        {
           
        }
    }
}
