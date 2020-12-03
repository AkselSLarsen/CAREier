using CAREier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Helpers
{
    public class Constructor
    {
        public JsonFileSystem CEREirefileCRUD;
        public FileCatalog OrderCatalog;
        public Constructor()
        {
            CEREirefileCRUD = new JsonFileSystem(@"Data\CEREire_Items.json");
            OrderCatalog = new FileCatalog(CEREirefileCRUD);
        }
    }
}
