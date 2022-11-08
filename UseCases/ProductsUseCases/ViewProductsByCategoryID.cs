using System;
using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class ViewProductsByCategoryID : IViewProductsByCategoryID
    {
        private readonly IProductRepository productRepository;
        public ViewProductsByCategoryID(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public IEnumerable<Product> Execute(int categoryId)
        {
            return productRepository.GetProductsByCategory(categoryId);
        }
    }
}
