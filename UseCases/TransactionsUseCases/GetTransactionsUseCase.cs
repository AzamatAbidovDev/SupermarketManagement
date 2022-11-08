using System;
using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class GetTransactionsUseCase : IGetTransactionsUseCase
    {
        private readonly ITransactionRepository transactionRepository;
        public GetTransactionsUseCase(ITransactionRepository _transactionRepository)
        {
            transactionRepository = _transactionRepository;
        }
        public IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate)
        {
            return transactionRepository.Search(cashierName, startDate, endDate);
        }
    }
}
