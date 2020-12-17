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
        public enum FileTypes { 
            Order,
            Pruduct,
            Buyer,
            Bringer,
            Store
        }

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>Returns a bool if error</returns>
        public bool update(int index,string key,object new_value)
        {
            if (index < 0 || index >= length()) return false;
            if (!_files[index].my_values.ContainsKey(key)) return false;
            _files[index].my_values[key] = new_value;
            return true;
        }
        public void update(DB_Item product,bool update_json = true)
        {
            if (product != null)
            {
                if (_files.Contains(product))
                    _files[_files.IndexOf(product)] = product;
            }
            if(update_json) saveAll();
        }
        public void update(DB_Item product, string key, object new_value, bool update_json = true)
        {
            if (product != null)
            {
                if (_files.Contains(product))
                    if (product.my_values.ContainsKey(key))
                        _files[_files.IndexOf(product)].my_values[key] = new_value;
            }
            if (update_json) saveAll();
        }
        
        
        public int length()
        {
            return _files.Count;
        }

        public int index(DB_Item item)
        {
            return _files.IndexOf(item);
        }
        public DB_Item itemName(string name)
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

        public List<DB_Item> readAll(bool load_json = true)
        {
            if(load_json) _files = _jsonfileSaver.Read();
            return _files.ToList();
        }
       
        public void saveAll()
        {
            _jsonfileSaver.Write(_files);
        }



    }
}