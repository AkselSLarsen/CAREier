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
    public class DeleteModel : PageModel
    {
        private ICRUD<Product> _newHandler;
        [BindProperty]
        public List<Product> ProductList { get; set; }

        [BindProperty]
        public Product Product { get; set; }

        public DeleteModel(ICRUD<Product> NewProduct)
        {
            _newHandler = NewProduct;
            ProductList = _newHandler.ReadAll();
            /*foreach (var var in _newHandler.ReadAll())
            {
                if (var is Product)
                {
                    ProductList.Add((Product)var);
                }
            }*/
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
            ProductList = _newHandler.ReadAll();
            int index = ProductList.IndexOf(Product);
            _newHandler.Delete(Product);
            return RedirectToPage("ProductCatalog");
        }
    }
}
