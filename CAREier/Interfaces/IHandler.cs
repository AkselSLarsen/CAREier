using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces {
    public interface IHandler<Item> {
        /// <summary>
        /// Adds the given item into the internal list.
        /// </summary>
        /// <param name="item">The item to be added</param>
        public void Create(Item item);

        /// <summary>
        /// Gets the number of items in the internal list.
        /// </summary>
        /// <returns>Returns the number of items in the internal list</returns>
        public int Count();

        /// <summary>
        /// Gets the item in at the given index of the internal list.
        /// </summary>
        /// <param name="index">The index location of the desired item, may cause exceptions if the index is equal to or higher than Count();</param>
        /// <returns>The item at the given index of the internal list</returns>
        public Item Read(int index);
        /// <summary>
        /// Returns a list representation of the handler.
        /// Keep in mind that this list is a copy and editing it will not change the state of the handler.
        /// </summary>
        /// <returns>The a list representation of the handler</returns>
        public List<Item> ReadAll();
        /// <summary>
        /// Replaces the "pre" parameter item with the "post" parameter item.
        /// May or may not replace more than one instance of "pre", depending on the implementation.
        /// </summary>
        /// <param name="pre">The item to be replaced</param>
        /// <param name="post">The item "pre" should be replaced with</param>
        //public void Update(Item pre, Item post);
        /// <summary>
        /// Replaces the item at the given index of the internal list with the "item" parameter.
        /// </summary>
        /// <param name="index">The index location to place item into, may cause exceptions if the index is equal to or higher than Count();</param>
        /// <param name="item">The item to place into the given index</param>
        /// <returns>The item that was replaced, meaning the item that could be found with a call of Read("index"); before this method was called</returns>
        //public Item Update(int index, Item item);

        /// <summary>
        /// Removes the given item from the internal list.
        /// May or may not remove all instances of the item or just one, depending on the implementation.
        /// </summary>
        /// <param name="item">The item to be removed from the internal list</param>

        public IProduct ReadByName(string name);
        public void Update(IProduct product);
        public void Delete(Item item);
        /// <summary>
        /// Removes the item at the given index location from the internal list.
        /// </summary>
        /// <param name="index">The index location in the internal list of the item that should be removed</param>
        /// <returns>The item that has been removed by this method, as if the Read(index); had been called before this</returns>
        public Item Delete(int index);
    }
}