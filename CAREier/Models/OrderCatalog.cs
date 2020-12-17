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
        public List<Order> ReadAll()
        {
            List<DB_Item> NewList = readAll();
            foreach (DB_Item item in NewList)
            {
                if (item.type == FileTypes.Order)
                    NewList.Add((Order)item);
            }
            return NewList;
        }
        public void Update(Order order)
        {
            update(order);
        }

        public void Delete(Order item)
        {
            Create(item);
        }

        public Order GetByName(string name)
        {
            return itemName(name);
        }

        public int Index(Order item)
        {
            return index(item);
        }
        public List<Order> Load()
        {
            List<Order> NewList = new List<Order>();
            foreach (DB_Item item in NewList)
            {
                if (item.type == FileTypes.Order)
                    NewList.Add((Order)item);
            }
            return NewList;
        }










    }
}
