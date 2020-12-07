using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Localizers;
using Microsoft.AspNetCore.Mvc;

namespace CAREier.Models {
    public class OrderCatalog /*: ICRUD<Order>*/ {
        private string _filelocation;
        private List<Order> _orders;

        public OrderCatalog() {
            _filelocation = @"Data\Orders.json";

            _orders = new List<Order>();

            //if (ReadState() != null) {
            //    _orders.AddRange(ReadState());
            //}
        }

        public void Create(Order item) {
            if (item != null) {
                foreach (var v in _orders) {
                    if (item.OrderID == v.OrderID) {
                        return;
                    }
                }
                _orders.Add(item);
                //WriteState();
            }
        }

        public Order Read(int index) {
            return _orders[index];
        }


        public List<Order> ReadAll() {
            return _orders.ToList();
        }

        public void Update(Order order) {
            if (order != null) {
                foreach (var o in _orders) {
                    if (o.Bringer == order.Bringer) {
                        o.MyStore = order.MyStore;
                        o.Products = order.Products;
                        o.Rating = order.Rating;
                        o.TotalPrice = order.TotalPrice;

                        //WriteState();
                    }
                }
            }
        }

        /*
        public void Delete(Order item) {
            if (item != null) {
                Order Temp = new Order();
                foreach (var v in _orders) {
                    if (item.Name == v.Name) {
                        Temp = v;
                    }
                }

                if (Temp != null) {
                    _orders.Remove(Temp);
                    WriteState();
                }

            }

        }

        public Order Delete(int index) {
            Order deleted = Read(index);
            _orders.RemoveAt(index);

            WriteState();

            return deleted;
        }

        private List<Order> ReadState() {
            return ReadState(_filelocation);
        }

        private void WriteState() {
            WriteState(_orders, _filelocation);
        }
        */
    }
}