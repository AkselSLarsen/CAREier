using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Models;
using CAREier.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages
{
   
    public class ShopCardModel : PageModel
    {
        public Buyer CurrentBuyer { get; set; }
        private ICRUD<Product> _products;
        public List<Product> Products { get; set; }
        public ShoppingCartService ChartService { get; }
        public List<Order> CurrentOrders { get; set; }
        public List<string> Tags { get; set; }

        [BindProperty]
        public Product PostProduct { get; set; }


        public Order ActivOrder { get; set; }


        public string StoreSort { get; set; }
        public ShopCardModel(ICRUD<Product> products)
        {
            StoreSort = "All";
            _products = products;
            Products = new List<Product>();
            foreach (var var in _products.ReadAll())
            {
                if (var is Product)
                {
                    Products.Add((Product)var);
                }
            }
            
            CurrentBuyer = new Buyer();
            ActivOrder = null;
        }
        /// <summary>
        /// Gets a list sorted after store ides, or all products
        /// </summary>
        /// <returns>List of Products</returns>
        public List<Product> SortedProductList()
        {
            if (ActivOrder == null) return Products;
            List<Product> Prods = new List<Product>();
            foreach (Product prod in Products)
            {
                if (!prod.HasStore(ActivOrder.MyStore)) continue;
                Prods.Add(prod);
            }

            return Prods;
        }
        
        public List<Order> SortedOrderList()
        {
            
            return CurrentBuyer.Orders;
        }

        public void OnGet()
        {
            Products = _products.ReadAll();
        }

        public void OnPostByItem(ICRUD<Order> order_crud)
        {
            if (ActivOrder == null) {
                Store foundStore = Global.FindShortest("all", false, CurrentBuyer.Location, PostProduct.Stores.ToArray());
                ActivOrder = new Order(CurrentBuyer, foundStore);
                ActivOrder.AddToProductList(PostProduct);
                order_crud.Create(ActivOrder);
            }
            else{
                ActivOrder.AddToProductList(PostProduct);
            }
            
            

           
             /* Products = ProductSorter.GetProductsWithTags(_products.ReadAll(), Tags);
              if (Products.Count == 0)
              {
                  Products = _products.ReadAll();
              }*/
        }
    }
}
