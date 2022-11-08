using System;
using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class GetTodayTransactionsUseCase : IGetTodayTransactionsUseCase
    {
        private readonly ITransactionRepository transactionRepository;
        public GetTodayTransactionsUseCase(ITransactionRepository _transactionRepository)
        {
            transactionRepository = _transactionRepository;
        }
        public IEnumerable<Transaction> Execute(string cashierName)
        {
            return transactionRepository.GetByDay(cashierName, DateTime.Now);
        }
    }
}
