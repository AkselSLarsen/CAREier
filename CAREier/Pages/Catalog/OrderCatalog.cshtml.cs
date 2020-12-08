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
    public class OrderCatalogModel : PageModel
    {
        private ICRUD<Order> _orders;
        public List<Order> Orders { get; set; }

        public OrderCatalogModel(ICRUD<Order> orders)
        {
            _orders = orders;
            Orders = new List<Order>();
            foreach (var Ord in _orders.ReadAll())
            {
                if (Ord is Order)
                {
                    Orders.Add((Order)Ord);
                }
            }
        }
        public void OnGet()
        {
            Orders = _orders.ReadAll();
        }
    }
}
