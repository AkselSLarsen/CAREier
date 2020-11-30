using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Interfaces;
using CAREier.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages.Catalog
{
    public class UpdateModel : PageModel
    {
        private ProductCatalog _newproduct;

        [BindProperty]
        public List<IProduct> ProductList { get; set; }

        [BindProperty]
        public Product Product { get; set; }

        public UpdateModel(ProductCatalog NewProduct)
        {
            _newproduct = NewProduct;
        }

        public IActionResult OnGet(string name)
        {
            Product = (Product) _newproduct.ReadByName(name);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _newproduct.Update(Product);
            return RedirectToPage("Catalog");
        }

    }
}
