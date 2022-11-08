using System;
using System.Collections.Generic;
using CoreBusiness;

namespace UseCases.DataStorePluginIntefaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        Product GetProductByID(int productId);
        void DeleteProduct(int productId);
        IEnumerable<Product> GetProductsByCategory(int categoryId);
    }
}
