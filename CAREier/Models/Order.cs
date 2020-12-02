using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Localizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Models
{
    public class Order : IOrder
    {
        private string _name;
        public string Name { get { return _name;  } set { _name = value; } }

        private IStore _store;
        public IStore MyStore { get { return _store; } set { _store = value; } }
        private List<IProduct> _products;
        public List<IProduct> Products { get { return _products; } set { _products = value; } }
        private LocalizedPrice _totalPrice;
        public LocalizedPrice TotalPrice { get { return _totalPrice; } set { _totalPrice = value; } }
        private string _OrderID;
        public string OrderID { get { return _OrderID; } set { _OrderID = value; } }

        public void AddProduct(IProduct item)//{
        {
            _products.Add(item);
        }

        public void RemoveProduct(IProduct item)//{
        {
            _products.Remove(item);
        }

        public void RemoveProductWithTags(params string[] tags)//{
        {
            List<Product> DeleteList = GetProductsWithTags(tags);
            foreach (var prod in DeleteList)
            {
                if(!_products.Contains(prod)) throw new System.ArgumentException("A imposible Error; A none existen product could not get deleted: tjeck order", "original");
                _products.Remove(prod);
            }
            DeleteList.Clear();
        }
        public List<Product> GetProduct(string name)//{
        {
            List<Product> NewProductsList = new List<Product>();
            foreach (var prod in _products)
            {
                if (prod is Product) 
                {
                    if (prod.Name == name)
                    {
                        NewProductsList.Add((Product)prod);
                    }
                }
            }
            return NewProductsList;
        }
        public Product GetFistProduct(string name)
        {
            foreach (var prod in _products)
            {
                if (prod is Product)
                {
                    if (prod.Name == name)
                    {
                        return (Product)prod;
                    }
                    
                }
            }
            return null;
        }
        public List<Product> GetProductsWithTags(params string[] tags)//{
        {
            List<IProduct> Products = ProductSorter.GetProductsWithTags(_products, tags);
            List<Product> NewProductsList = new List<Product>(Products.Count);
            foreach (var prod in _products)
            {
                NewProductsList.Add((Product)prod);
            }
            return NewProductsList;
        }
        
    }
}
