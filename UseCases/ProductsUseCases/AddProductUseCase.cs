using System;
using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository productRepository;
        public AddProductUseCase(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public void Execute(Product product)
        {
            productRepository.AddProduct(product);
        }
    }
}
