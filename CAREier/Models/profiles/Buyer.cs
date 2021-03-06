﻿using CAREier.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Models
{
    public class Buyer : IUser
    {
        private string _name;
        private string _email;
        private string _phone;
        private string _adress;
        //private TransactionAccount _paymentMethod;
        private string _username;
        private string _password;
        //For oder stuff
        public bool OrderActive;
        private List<Order> _orders;
        private int Ordindex;
        private WorldPoint _location;
        
        public Buyer()
        {
            OrderActive = false;
          
        }

        public Buyer(string name, string email, string phone, string adress, string username, string password)
        {
            _name = name;
            _email = email;
            _phone = phone;
            _adress = adress;
            //_paymentMethod = paymentMethod;
            _orders = new List<Order>();
            _username = username;
            _password = password;
            OrderActive = false;

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

        public List<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
        [JsonConverter(typeof(WorldPointConverter))]
        public WorldPoint Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public Order ActiveOrder
        {
            get
            {
                if (Ordindex >= _orders.Count) return null;
                if (Ordindex < 0) return null;
                return _orders[Ordindex];
            }
            set {
                if (_orders.Count > 0)
                     _orders[Ordindex] = value;
            }
        }
        /// <summary>
        /// if the buyer allrady have bought this item
        /// </summary>
        /// <param name="ClosestStore"></param>
        public bool RebuyProduct(Product proditem)
        {
            
            foreach (Product item in ActiveOrder.Products)
            {
                if (item.id == proditem.id) {
                    ActiveOrder.ProductCount[item.id]++;
                    return true;
                }
            }
            return false;
        }
        public void MakeOrder(Store ClosestStore)
        {
            Order ord = new Order(this, ClosestStore);
            Orders.Add(ord);
            Ordindex = Orders.Count - 1;
            // ord.AddToProductList(product);
            OrderActive = true;
        }
        public void ClearOrders()
        {
            Orders.Clear();
            OrderActive = false;
        }
    }
}