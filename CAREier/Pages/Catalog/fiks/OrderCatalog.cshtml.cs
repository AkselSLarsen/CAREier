using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages
{
    public class OrderCatalogModel : PageModel
    {
        private ICRUD<Order> _orders;

        public List<Order> Orders { get; set; }
        [BindProperty]
        public Order Order { get; set; }

        public OrderCatalogModel(ICRUD<Order> orders)
        {
            _orders = orders;
            Orders = new List<Order>();
            foreach (var ord in _orders.ReadAll())
            {
                if (ord is Order)
                {
                    Orders.Add((Order)ord);
                }
            }

        }
        public void OnGet()
        {
            Orders = new List<Order>();
        }

    }
}