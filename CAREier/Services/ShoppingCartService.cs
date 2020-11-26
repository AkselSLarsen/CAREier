using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Services
{
    public class ShoppingCartService
    {
        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0.00M;

            /* foreach (var v in _cartItems)
             {
                 totalPrice = totalPrice + (decimal)v.Price ;
             }*/
            return totalPrice;
        }
    }
}
