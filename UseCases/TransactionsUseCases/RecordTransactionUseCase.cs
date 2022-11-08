using System;
using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        public RecordTransactionUseCase(IGetProductByIDUseCase _getProductByIDUseCase, ITransactionRepository _transactionRepository)
        {
            getProductByIDUseCase = _getProductByIDUseCase;
            transactionRepository = _transactionRepository;
        }
        private readonly IGetProductByIDUseCase getProductByIDUseCase;
        private readonly ITransactionRepository transactionRepository;
        public void Execute(string cashierName, int productId, double qty)
        {
            var product = getProductByIDUseCase.Execute(productId);
            transactionRepository.Save(cashierName, productId, product.Name, product.Price.Value, product.Quantity.Value, qty, product.Unit);
        }
    }
}
