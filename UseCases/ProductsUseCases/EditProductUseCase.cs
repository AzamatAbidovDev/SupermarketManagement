using System;
using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository productRepository;
        public EditProductUseCase(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public void Execute(Product product)
        {
            productRepository.UpdateProduct(product);
        }
    }
}
