using System;
using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository productRepository;
        public DeleteProductUseCase(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public void Delete(Product product)
        {
            productRepository.DeleteProduct(product);
        }
    }
}
