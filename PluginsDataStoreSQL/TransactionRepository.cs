using System;
using System.Collections.Generic;
using System.Linq;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;
using Microsoft.EntityFrameworkCore;

namespace PluginsDataStoreSQL
{
    public class TransactionRepository: ITransactionRepository
    {
        private readonly MarketContext db;
        public TransactionRepository(MarketContext _db)
        {
            db = _db;
        }

        public IEnumerable<Transaction> Get(string cashierName)
        {
            return db.Transactions.ToList();
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return db.Transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
                return db.Transactions.Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
                x.TimeStamp.Date == date.Date);
        }

        public void Save(string cashierName, int productId, string productName, double price, double beforeQty, double soldQty, string unit)
        {
            var transaction = new Transaction
            {
                ProductID = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                Unit = unit,
                CashierName = cashierName
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return db.Transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            else
                return db.Transactions.Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
                x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
        }
    }
}
