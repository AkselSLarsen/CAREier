using CAREier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Models
{
    public class Bringer : IUser
    {
        private string _name;
        private string _email;
        private string _phone;
        private double _rating;
        //private TransactionAccount _cardNumber;
        private List<Order> _orders;
        private string _username;
        private string _password;
        private WorldPoint _location;

        public Bringer()
        {
            
        }
        public Bringer(string name, string email, string phone, double rating, List<Order> orders, string username, string password)
        {
            _name = name;
            _email = email;
            _phone = phone;
            _rating = rating;
            //_cardNumber = cardnumber;
            _orders = orders;
            _username = username;
            _password = password;

        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public WorldPoint Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public double Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        /*public TransactionAccount CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
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
