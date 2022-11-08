using System;
using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class GetProductByIDUseCase : IGetProductByIDUseCase
    {
        private readonly IProductRepository productRepository;
        public GetProductByIDUseCase(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public Product Execute(int productId)
        {
            return productRepository.GetProductByID(productId);
        }
    }
}
