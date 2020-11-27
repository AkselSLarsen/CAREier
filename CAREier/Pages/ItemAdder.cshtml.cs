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
            Order order = new Order();
            order.OrderID = 12;
            order.Student = Student;
            order.Books = cart.GetOrderedBooks();
            order.DateTime = DateTime.Now;
            repository.AddOrder(order);
            return RedirectToPage("Order", Student);
        }
    }
}
