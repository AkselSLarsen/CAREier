using CAREier.Interfaces;
using System.Collections.Generic;
using CAREier.Models;

namespace CAREier.Helpers {
    public static class ProductSorter {
        /// <summary>
        /// A sorting method for products, taking in a list of products and a tag and then returning all products in the list with the given tags.
        /// </summary>
        /// <param name="products">The products to be looked through</param>
        /// <param name="tag">The tag the products must have</param>
        /// <returns>A list of products from the "products" parameter with the given tag from the "tag" parameter</returns>
        public static List<Product> GetProductsWithTag(List<Product> products, string tag) {
            List<Product> re = new List<Product>();
            foreach(Product product in products) {
                if(product.Tags.Contains(tag)) {
                    re.Add(product);
                }
            }
            return re;
        }

        /// <summary>
        /// A sorting method for products, taking in a list of products and a list of tags and then returning all products in the list with all the given tags.
        /// </summary>
        /// <param name="products">>The products to be looked through</param>
        /// <param name="tags">The tags the products must have</param>
        /// <returns>A list of products from the "products" parameter with all the given tags from the "tags" parameter</returns>
        public static List<Product> GetProductsWithTags(List<Product> products, string[] tags) {
            List<Product> re = new List<Product>();
            foreach (Product product in products) {
                bool hasAll = true;
                foreach (string tag in tags) {
                    if(!product.Tags.Contains(tag)) {
                        hasAll = false;
                    }
                }
                if(hasAll) {
                    re.Add(product);
                }
            }
            return re;
        }
        /// <summary>
        /// A sorting method for products, taking in a list of products and a list of tags and then returning all products in the list with all the given tags.
        /// </summary>
        /// <param name="products">>The products to be looked through</param>
        /// <param name="tags">The tags the products must have</param>
        /// <returns>A list of products from the "products" parameter with all the given tags from the "tags" parameter</returns>
        public static List<Product> GetProductsWithTags(List<Product> products, List<string> tags) {
            return GetProductsWithTags(products, tags.ToArray());
        }
    }
}