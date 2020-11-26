using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces {
    public interface IHandler<Item> {
        public void Create(Item item);

        public Item Read(int index);

        public Item Update(Item pre, Item post);
        public Item Update(int index, Item item);

        public void Delete(Item item);
        public void Delete(int index);
    }
}