﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;

namespace CAREier.Models.profiles
{
    public class BuyerCatalog : ICRUD<Buyer>
    {
        private List<Buyer> _buyers;

        private string _filelocation;

        public BuyerCatalog()
        {
            _filelocation = @"Data/Buyers.json";

            _buyers = ReadState();

            if (_buyers == null) _buyers = new List<Buyer>();
        }

        public void Create(Buyer item)
        {
            _buyers.Add(item);

            WriteState();
        }

        public Buyer Read(int index)
        {
            return _buyers[index];
        }

        public List<Buyer> ReadAll()
        {
            return _buyers;
        }

        public void Update(Buyer item)
        {
            if (item != null)
            {
                foreach (var b in _buyers)
                {
                    if (b.Username == item.Username)
                    {
                        
                        b.Name = item.Name;
                        b.Email = item.Email;
                        b.Phone = item.Phone;
                        b.Adress = item.Adress;
                        //b.PaymentMethod = item.PaymentMethod;
                        b.Orders = item.Orders;
                        b.Username = item.Username;
                        b.Password = item.Password;

                        WriteState();
                    }
                }
            }
        }

        public void Delete(Buyer item)
        {
            if (item != null)
            {
                Buyer Temp = new Buyer();
                foreach (Buyer b in _buyers)
                {
                    if (item.Name == b.Name)
                    {
                        Temp = b;
                    }
                }

                if (Temp != null)
                {
                    _buyers.Remove(Temp);
                    WriteState();
                }

            }
        }

        private List<Buyer> ReadState()
        {
            return JsonFileSystem.ReadBuyer(_filelocation);
        }
        private void WriteState()
        {
            JsonFileSystem.WriteBuyer(_buyers, _filelocation);
        }
    }
}
