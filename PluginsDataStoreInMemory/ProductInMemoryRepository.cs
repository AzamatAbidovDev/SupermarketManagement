using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UseCases.DataStorePluginIntefaces;

namespace PluginsDataStoreInMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;
        public ProductInMemoryRepository()
        {
            products = new List<Product>
            {
                new Product { ProductID = 1, CategoryID = 1, Name = "Coffee", Quantity = 150, Price = 3.99 },
                new Product { ProductID = 2, CategoryID = 1, Name = "Tea", Quantity = 270, Price = 1.99 },
                new Product { ProductID = 3, CategoryID = 2, Name = "Brown bread", Quantity = 310, Price = 0.99 }
            };
        }
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (products != null && products.Count > 0)
            {
                var maxID = products.Max(x => x.ProductID);
                product.ProductID = maxID + 1;
            }
            else product.ProductID = 1;

            products.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductByID(product.ProductID);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.CategoryID = product.CategoryID;
                productToUpdate.Price = product.Price;
                productToUpdate.Quantity = product.Quantity;
            }
        }
        public Product GetProductByID(int productId)
        {
            return products.FirstOrDefault(x => x.ProductID == productId);
        }
        public void DeleteProduct(int productId)
        {
            products.Remove(GetProductByID(productId));
        }
        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return products.Where(x => x.CategoryID == categoryId);
        }
    }
}
