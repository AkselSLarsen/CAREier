using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Interfaces;
using CAREier.Models;
using CAREier.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages
{
    public class ItemAdderModel : PageModel
    {
        [BindProperty]
        public IOrder Order { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Appears to have been copied in from the bookstore exercises, please keep such things in comments in the future.
            /*
            Order order = new Order();
            order.OrderID = 12;
            order.Student = Student;
            order.Books = cart.GetOrderedBooks();
            order.DateTime = DateTime.Now;
            repository.AddOrder(order);
            return RedirectToPage("Order", Student);
            */
            return null;
        }
    }
}
