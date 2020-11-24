using CAREier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Helpers {
    public static class ProductSorter {
        /// <summary>
        /// A sorting method for products, taking in a list of products and a tag and then returning all products in the list with the given tags.
        /// </summary>
        /// <param name="products">The products to be looked through</param>
        /// <param name="tag">The tag the products must have</param>
        /// <returns>A list of products from the "products" parameter with the given tag from the "tag" parameter</returns>
        public static List<IProduct> GetProductsWithTag(List<IProduct> products, string tag) {
            List<IProduct> re = new List<IProduct>();
            foreach(IProduct product in products) {
                if(product.Tags.Contains(tag)) {
                    re.Add(product);
                }
            }
            return re;
        }
    }
}