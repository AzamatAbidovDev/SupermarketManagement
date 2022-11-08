using System;
using CoreBusiness;
using System.Collections.Generic;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class ViewProductsUseCase : IViewProductsUseCase
    {
        private readonly IProductRepository productRepository;
        public ViewProductsUseCase(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public IEnumerable<Product> Execute()
        {
            return productRepository.GetProducts();
        }
    }
}
