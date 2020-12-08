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

        public Buyer(string name, string email, string phone, string adress, List<Order> orders, string username, string password)
        {
            _name = name;
            _email = email;
            _phone = phone;
            _adress = adress;
            //_paymentMethod = paymentMethod;
            _orders = orders;
            _username = username;
            _password = password;

        }

        public string Name
        {
            get { return _name;}
            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }

        /*public TransactionAccount PaymentMethod
        {
            get { return _paymentMethod; }
            set { _paymentMethod = value; }
        }*/

        public List<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
