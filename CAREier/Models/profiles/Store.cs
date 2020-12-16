using CAREier.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Models
{
    public class Store : IUser
    {
        private string _name;
        private string _email;
        private string _adress;
        private string _openingTimes;
        //private TransactionAccount _accountNumber;
        private double _rating;
        private string _username;
        private string _password;
        private WorldPoint _location;
        [JsonConverter(typeof(WorldPointConverter))]
        public WorldPoint Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public Store()
        {
           
        }
        public Store(string name, string email, string adress, string openingtimes, double rating, string username, string password)
        {
            _name = name;
            _email = email;
            _adress = adress;
            _openingTimes = openingtimes;
            //_accountNumber = accountnumber;
            _rating = rating;
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


        public string Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }

        public string OpeningTimes
        {
            get { return _openingTimes; }
            set { _openingTimes = value; }
        }
        /*public TransactionAccount AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }*/

        public double Rating
        {
            get { return _rating; }
            set { _rating = value; }
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
