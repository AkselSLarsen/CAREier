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
        private ICRUD<Order> _orders { get; set; }

        public List<Product> Products { get; set; }
        public ShoppingCartService ChartService { get; }
        public List<string> Tags { get; set; }

        //[FromRoute]
        //public long? Id { get; set; }

        // [BindProperty]
        // public Product PostProduct { get; set; }

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

            SortedProductList();
           
            // = new Buyer();
            // ActivOrder = null;
        }
        /// <summary>
        /// Gets a list sorted after store ides, or all products
        /// </summary>
        /// <returns>List of Products</returns>
        public void SortedProductList()
        {
            if (CurrentBuyer.OrderActive)
            {
                List<Product> ToBeFilterdProducts = _products.ReadAll();
                Products = new List<Product>();
                foreach (Product prod in ToBeFilterdProducts)
                {
                    if(prod.Store == null) continue;
                    if (prod.Store.Name != CurrentBuyer.ActiveOrder.MyStore.Name) continue;
                    Products.Add(prod);
                

                }
            }
            else
            {
                Products = _products.ReadAll();
            }
            if (Products == null) Products = new List<Product>(); 
           
        }
   

        public void OnGet(string index)
        {
            

        }
        public Product FindProduct(int prodid)
        {
            if (Products == null) return null;
            foreach (Product prod in Products)
            {
                if (prod.id == prodid) return prod;
            }
            return null;
        }
    public void OnPost(Product prod)
        {
            string name = Request.Path;
            name = name.Substring(10, name.Length - 10);
            int prodId = int.Parse(name);
            Product PostProduct = FindProduct(prodId);
            if (PostProduct == null) return;
            if (PostProduct.Store == null) return;
            if (!CurrentBuyer.OrderActive) {
                //Obselte code Store foundStore = Global.FindShortest("all", false, CurrentBuyer.Location, PostProduct.Store);
                CurrentBuyer.MakeOrder(PostProduct.Store);
                SortedProductList();
            }
            if (!CurrentBuyer.RebuyProduct(prod))
            {
                CurrentBuyer.ActiveOrder.ProductCount.Add(prod.id, 1);
                CurrentBuyer.ActiveOrder.Products.Add(PostProduct);
            }
            


            /*
            if (ActivOrder ) {
               
                
                ActivOrder.Products.Add(PostProduct.LookUpInfo());
                order_crud.Create(ActivOrder);
          
                ActivOrder.Products.Add();
            }
             /* Products = ProductSorter.GetProductsWithTags(_products.ReadAll(), Tags);
              if (Products.Count == 0)
              {
                  Products = _products.ReadAll();
              }*/
        }
    }
}
