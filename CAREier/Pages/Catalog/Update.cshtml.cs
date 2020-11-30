using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages.Catalog
{
    public class UpdateModel : PageModel
    {
        private IHandler<IProduct> _newproduct;

        [BindProperty]
        public List<IProduct> ProductList { get; set; }

        [BindProperty]
        public IProduct Product { get; set; }

        public UpdateModel(IHandler<IProduct> NewProduct)
        {
            _newproduct = NewProduct;
        }

        public IActionResult OnGet(int index)
        {
            Product = _newproduct.Read(index);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _newproduct.Update()
            return RedirectToPage("Catalog");
        }

    }
}
