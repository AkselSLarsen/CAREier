using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Models
{
    public class Buyer
    {
        private string _name;
        private string _email;
        private string _phone;
        private string _adress;
        //private TransactionAccount _paymentMethod;
        private List<Order> _orders;
        private string _username;
        private string _password;

        public Buyer(string name)
        {
            
        }
    }
}
