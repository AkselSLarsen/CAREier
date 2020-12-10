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


        public ShopCardModel(ICRUD<Product> products)
        {
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
        }
        public List<Order> SortedOrderList()
        {
            
            return CurrentBuyer.Orders;
        }

        public void OnGet()
        {
            Products = _products.ReadAll();
        }

        public void OnPostByItem()
        {
             CurrentBuyer.MakeOrder(PostProduct);
             /* Products = ProductSorter.GetProductsWithTags(_products.ReadAll(), Tags);
              if (Products.Count == 0)
              {
                  Products = _products.ReadAll();
              }*/
        }

        public string FormalizeTags(List<string> tags)
        {
            return TagFormalizer.TagsToString(tags);
        }

    }
}
