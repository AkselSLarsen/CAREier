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
    public class CreateModel : PageModel
    {
        private ICRUD<Product> _newHandler;
        [BindProperty]
        public List<Product> ProductList { get; set; }

        [BindProperty]
        public Product Product { get; set; }

        public CreateModel(ICRUD<Product> NewProduct)
        {
            _newHandler = NewProduct;
            ProductList = new List<Product>();
            foreach (var var in NewProduct.ReadAll())
            {
                if (var is Product)
                {
                    ProductList.Add((Product)var);
                }
            }
        }

        public IActionResult OnGet(int id)
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _newHandler.Create(Product);
            return RedirectToPage("Catalog");
        }
    }
}
