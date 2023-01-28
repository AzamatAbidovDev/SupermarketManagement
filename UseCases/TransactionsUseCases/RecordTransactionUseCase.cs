using System;
using System.Linq;
using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        public RecordTransactionUseCase(IGetProductByIDUseCase _getProductByIDUseCase, ITransactionRepository _transactionRepository, IGetTodayTransactionsUseCase _getTodayTransactionsUseCase)
        {
            getProductByIDUseCase = _getProductByIDUseCase;
            transactionRepository = _transactionRepository;
            getTodayTransactionsUseCase = _getTodayTransactionsUseCase;
        }
        private readonly IGetProductByIDUseCase getProductByIDUseCase;
        private readonly ITransactionRepository transactionRepository;
        private readonly IGetTodayTransactionsUseCase getTodayTransactionsUseCase;
        public void Execute(string cashierName, int productId, double qty)
        {
            var product = getProductByIDUseCase.Execute(productId);
            transactionRepository.Save(cashierName, productId, product.Name, product.Price.Value, product.Quantity.Value, qty, product.Unit);
        }
        public void OnMinusButton(string cashierName, int productId)
        {
            transactionRepository.MinusButton(cashierName, productId);
        }
        public void OnPlusButton(string cashierName, int productId)
        {
            transactionRepository.PlusButton(cashierName, productId);
        }
    }
}
