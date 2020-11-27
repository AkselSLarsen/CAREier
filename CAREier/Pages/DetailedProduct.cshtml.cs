using CAREier.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CAREier.Pages {
    public class DetailedProductModel : PageModel {

        private List<IProduct> products { get; set; }
        public IProduct Product { get; set; }

        DetailedProductModel(IHandler<IProduct> handler) {
            products = handler.ReadAll();
        }

        public void OnGet(int id) {
            Product = products[id];
        }
    }
}