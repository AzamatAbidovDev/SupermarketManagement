using System;
using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IRecordTransactionUseCase recordTransactionUseCase;
        public SellProductUseCase(IProductRepository _productRepository, IRecordTransactionUseCase _recordTransactionUseCase)
        {
            productRepository = _productRepository;
            recordTransactionUseCase = _recordTransactionUseCase;
        }
        public void Execute(string cashierName, int productId, double qtyToSell)
        {
            var product = productRepository.GetProductByID(productId);

            if (product == null) return;

            recordTransactionUseCase.Execute(cashierName, productId, qtyToSell);
            product.Quantity -= qtyToSell;
            productRepository.UpdateProduct(product);
            
        }
    }
}
