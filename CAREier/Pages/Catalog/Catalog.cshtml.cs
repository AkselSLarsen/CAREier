using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Helpers;
using CAREier.Interfaces;
using CAREier.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages
{
    public class CatalogModel : PageModel
    {
        private ICRUD<Product> _products;

        public List<Product> Products { get; set; }
        [BindProperty]
        public List<string> Tags { get; set; }

        public CatalogModel(ICRUD<Product> products)
        {
            _products = products;
            Products = new List<Product>();
            foreach (var var in _products.ReadAll())
            {
                if (var is Product)
                {
                    Products.Add((Product)var);
                }
            }
        }
        public void OnGet()
        {
            Products = _products.ReadAll();
        }

        public void OnPost()
        {
            Products = ProductSorter.GetProductsWithTags(Products, Tags);
        }
        /*
        public string Tags(int index) {
            if(index >= Products.Count) { return ""; }
            if(Products[index].Tags.Count == 0) { return ""; }

            string re = "";
            foreach(string tag in Products[index].Tags) {
                re += tag + " ";
            }
            return re;
        }
        */
        public string FormalizeTags(List<string> tags) {
            string re = "";
            foreach (string tag in tags) {
                re += tag + " ";
            }
            return re;
        }
    }
}