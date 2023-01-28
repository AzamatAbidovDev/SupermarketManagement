using System;
using System.Collections.Generic;
using CoreBusiness;

namespace UseCases.DataStorePluginIntefaces
{
    public interface ITransactionRepository
    {
        public IEnumerable<Transaction> Get(string cashierName);
        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date);
        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate);
        public void MinusButton(string cashierName, int productId);
        public void PlusButton(string cashierName, int productId);
        public void Save(string cashierName, int productId, string productName, double price, double beforeQty, double soldQty, string unit);
    }
}
