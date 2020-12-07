using CAREier.Interfaces;
using CAREier.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CAREier.Pages {
    public class DetailedProductModel : PageModel {

        private List<Product> products { get; set; }
        public IProduct Product { get; set; }

        DetailedProductModel(ICRUD<Product> catalog) {
            products = catalog.ReadAll();
        }

        public void OnGet(int id) {
            Product = products[id];
            
        }
    }
}