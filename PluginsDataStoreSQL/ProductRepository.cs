using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginIntefaces;
using CoreBusiness;

namespace PluginsDataStoreSQL
{
    public class ProductRepository: IProductRepository
    {
        private readonly MarketContext db;
        public ProductRepository(MarketContext _db)
        {
            db = _db;
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = db.Products.Find(productId);
            if (product == null) return;

            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product GetProductByID(int productId)
        {
            return db.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return db.Products.Where(x => x.CategoryID == categoryId).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var prod = db.Products.Find(product.ProductID);
            prod.CategoryID = product.CategoryID;
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;
            prod.Unit = product.Unit;

            db.SaveChanges();
        }
    }
}
