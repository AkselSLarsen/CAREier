using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces {
    interface IHandler<Item> {
        public void Create(Item item);

        public Item Read();

        public Item Update(Item pre, Item post);

        public void Delete(Item item);
    }
}