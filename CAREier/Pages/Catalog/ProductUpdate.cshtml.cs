using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Interfaces;
using CAREier.Models;
using CAREier.Models.profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages.Catalog
{
    public class UpdateModel : PageModel
    {
        private ICRUD<Product> _newHandler;
        [BindProperty]
        public List<Product> ProductList { get; set; }

        [BindProperty]
        public Product Product { get; set; }


        public Store CurrentStore { get; set; }

        public UpdateModel(ICRUD<Product> NewProduct, IUser user)
        {
            User storeUser = (User)user;
            if (storeUser.Profile is Store)
                CurrentStore = (Store)storeUser.Profile;
            else
                RedirectToPage("Index");

            _newHandler = NewProduct;
            ProductList = new List<Product>(); 
            foreach (var var in NewProduct.ReadAll())
            {
                if (var is Product)
                {
                    ProductList.Add((Product) var);
                }
            }
        }

        public IActionResult OnGet(int id)
        {
            Product = ProductList[id];
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Sets store, but only info gets saved in newHandler
            Product.Store = CurrentStore;
            _newHandler.Update(Product);
            return RedirectToPage("ProductCatalog");
        }

    }
}
