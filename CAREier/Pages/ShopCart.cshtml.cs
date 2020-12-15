using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Models;
using CAREier.Models.profiles;
using CAREier.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages
{
    public class ShopCardModel : PageModel
    {
        public Buyer CurrentBuyer { get; set; }
        private ICRUD<Product> _products;
        private ICRUD<Order> _orders;
        public List<Product> Products { get; set; }
        public ShoppingCartService ChartService { get; }
        public List<Order> CurrentOrders { get; set; }
        public List<string> Tags { get; set; }

        [BindProperty]
        public Product PostProduct { get; set; }


        public Order ActivOrder { get; set; }


        public string StoreSort { get; set; }
        public ShopCardModel(IUser user,ICRUD<Product> products, ICRUD<Order> order_crud)
        {
            //if (Products != null) return;

            // StoreSort = "All";

            _products = products;
            _orders = order_crud;
            User shopUser = (User)user;
            if (shopUser.Profile is Buyer)
                CurrentBuyer = (Buyer)shopUser.Profile;
            else
                RedirectToPage("Index");

            // = new Buyer();
            // ActivOrder = null;
        }
        /// <summary>
        /// Gets a list sorted after store ides, or all products
        /// </summary>
        /// <returns>List of Products</returns>
        public List<Product> SortedProductList()
        {
            Products = _products.ReadAll();
            return Products;
            // if (ActivOrder == null) 
            // List<Product> Prods = new List<Product>();
            // foreach (Product prod in Products)
            //{
            // if (!prod.HasStore(ActivOrder.MyStore)) continue;
            // Prods.Add(prod);
            //}
            // return Prods;
        }
        public List<Order> SortedOrderList()
        {
            //CurrentBuyer.Orders;
            // ICRUD<Product> Prods
            return CurrentBuyer.Orders;
        }

        public void OnGet()
        {
           
        }

        public void OnPostByItem()
        {
            //CurrentBuyer.
            /*
            if (ActivOrder == null) {
                Store foundStore = Global.FindShortest("all", false, CurrentBuyer.Location, PostProduct.Stores.ToArray());
                ActivOrder = new Order(CurrentBuyer, foundStore);
                ActivOrder.Products.Add(PostProduct.LookUpInfo());
                order_crud.Create(ActivOrder);
            }
            else{
                ActivOrder.Products.Add(PostProduct.LookUpInfo());
            }
             /* Products = ProductSorter.GetProductsWithTags(_products.ReadAll(), Tags);
              if (Products.Count == 0)
              {
                  Products = _products.ReadAll();
              }*/
        }
    }
}
