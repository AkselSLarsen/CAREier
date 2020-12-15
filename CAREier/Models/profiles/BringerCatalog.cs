using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;

namespace CAREier.Models.profiles
{
    public class BringerCatalog : ICRUD<Bringer>
    {

        private List<Bringer> _bringers;

        private string _filelocation;

        public BringerCatalog()
        {
            _filelocation = @"Data/Bringers.json";

            _bringers = ReadState();

            if (_bringers == null) _bringers = new List<Bringer>();
        }
        public void Create(Bringer item)
        {
            if (item == null) return;
            _bringers.Add(item);

            WriteState();
        }

        public Bringer Read(int index)
        {
            return _bringers[index];
        }

        public List<Bringer> ReadAll()
        {
            return _bringers;
        }

        public void Update(Bringer item)
        {
            if (item != null)
            {
                foreach (var b in _bringers)
                {
                    if (b.Username == item.Username)
                    {

                        b.Name = item.Name;
                        b.Email = item.Email;
                        b.Phone = item.Phone;
                        b.Rating = item.Rating;
                        //b.CardNumber = item.CardNumber;
                        b.Orders = item.Orders;
                        b.Username = item.Username;
                        b.Password = item.Password;

                        WriteState();
                    }
                }
            }
        }

        public void Delete(Bringer item)
        {
            if (item != null)
            {
                Bringer Temp = new Bringer();
                foreach (Bringer b in _bringers)
                {
                    if (item.Name == b.Name)
                    {
                        Temp = b;
                    }
                }

                if (Temp != null)
                {
                    _bringers.Remove(Temp);
                    WriteState();
                }

            }
        }

        private List<Bringer> ReadState()
        {
            return JsonFileSystem.ReadBringers(_filelocation);
        }
        private void WriteState()
        {
            JsonFileSystem.WriteBringers(_bringers, _filelocation);
        }
    }
}
