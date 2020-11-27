using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Interfaces;
using CAREier.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages
{
    public class ShopCardModel : PageModel
    {
        public ShoppingCartService ChartService { get; }
        public List<IOrder> Orders { get; set; }
    
        public ShopCardModel()
        {
            //repo = repository;
            //ChartService = chart;
            //OrderedBooks = new List<Book>();
        }
        public void OnGet()
        {
            // Book book = repo.GetBook(isbn);
            //ChartService.Add(book);
            //OrderedBooks = ChartService.GetOrderedBooks();
            //return Page();
        }

        public IActionResult OnPostDelete(string isbn)
        {
            //ChartService.RemoveBook(isbn);

            //OrderedBooks = ChartService.GetOrderedBooks();
            return Page();
        }
      
    }
}
