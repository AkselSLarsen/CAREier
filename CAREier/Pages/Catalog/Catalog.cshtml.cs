using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Interfaces;
using CAREier.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages
{
    public class CatalogModel : PageModel
    {
        private IHandler<IProduct> _products;

        public List<IProduct> Products;
        public void OnGet()
        {
            Products = _products.ReadAll();
        }
    }
}
