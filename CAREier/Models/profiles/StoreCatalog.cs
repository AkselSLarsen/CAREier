using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;

namespace CAREier.Models.profiles
{
    public class StoreCatalog : ICRUD<Store>
    {
        private List<Store> _stores;

        private string _filelocation;

        public StoreCatalog()
        {
            _filelocation = @"Data/Stores.json";

            _stores = ReadState();

            if (_stores == null) _stores = new List<Store>();
        }
        public void Create(Store item)
        {
            if (item == null) return; 
            _stores.Add(item);

            WriteState();
        }

        public Store Read(int index)
        {
            return _stores[index];
        }

        public List<Store> ReadAll()
        {
            return _stores;
        }

        public void Update(Store item)
        {
            if (item != null)
            {
                foreach (var b in _stores)
                {
                    if (b.Username == item.Username)
                    {

                        b.Name = item.Name;
                        b.Email = item.Email;
                        b.Adress = item.Adress;
                        b.OpeningTimes = item.OpeningTimes;
                        //b.AccountNumber = item.AccountNumber;
                        b.Rating = item.Rating;
                        b.Username = item.Username;
                        b.Password = item.Password;

                        WriteState();
                    }
                }
            }
        }

        public void Delete(Store item)
        {
            if (item != null)
            {
                Store Temp = new Store();
                foreach (Store b in _stores)
                {
                    if (item.Name == b.Name)
                    {
                        Temp = b;
                    }
                }

                if (Temp != null)
                {
                    _stores.Remove(Temp);
                    WriteState();
                }

            }
        }

        private List<Store> ReadState()
        {
            return JsonFileSystem.ReadStores(_filelocation);
        }
        private void WriteState()
        {
            JsonFileSystem.WriteStores(_stores, _filelocation);
        }
    }
}
