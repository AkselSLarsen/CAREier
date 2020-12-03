using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Localizers;

namespace CAREier.Models
{
    public class FileCatalog
    {
        private JsonFileSystem _jsonfileSaver;

        public FileCatalog(JsonFileSystem fileSaver)
        {
            _jsonfileSaver = fileSaver;
            
        }
        private List<DB_Item> _files;
        
        public void create(DB_Item item)
        {
            if (item != null)
            {
                _files.Add(item);
            }
        }
        public void delete(DB_Item item)
        {
            if (item != null)
            {
                _files.Remove(item);
            }
        }
        public void update(DB_Item product)
        {
            if (product != null)
            {
                foreach (var p in _files)
                {
                    if (p.Name == product.Name)
                    {
                        /*p.Name = product.Name;
                        p.Price = product.Price;
                        p.Weight = product.Weight;
                        p.Tags = product.Tags;
                        p.Picture = product.Picture;*/
                    }
                }
            }
        }
        public void save()
        {
            _JsonfileSaver.Write(_files);
        }
        public List<DB_Item> load()
        {
           return _JsonfileSaver.Read();
        }
        public int length()
        {
            return _files.Count;
        }

        public int index(DB_Item item)
        {
            return _files.IndexOf(item);
        }
        public DB_Item ItemName(string name)
        {
            foreach (var p in _files)
            {
                if (p.Name == name)
                {
                    return p;
                }
            }
            return new Order();
        }

        public List<DB_Item> readAll()
        {
            return _files.ToList();
        }
        public List<DB_Item> readAll()
        {
            return _files.ToList();
        }
       


    }
}