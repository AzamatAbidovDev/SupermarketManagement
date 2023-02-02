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
        private readonly IProductRepository productRepository;
        public TransactionRepository(MarketContext _db, IProductRepository _productRepository)
        {
            db = _db;
            productRepository = _productRepository;
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

        public void MinusButton(string cashierName, int productId)
        {
            IEnumerable<Transaction> transactions = GetByDay(cashierName, DateTime.Today);           
            var transaction = transactions.FirstOrDefault(x => x.ProductID == productId);
            var product = productRepository.GetProductByID(productId);
            product.Quantity++;
            transaction.SoldQty--;
            transaction.BeforeQty = product.Quantity.Value;
            if (transaction.SoldQty == 0)
                db.Transactions.Remove(transaction);                    
            else db.Transactions.Update(transaction);
            db.SaveChanges();
        }
        public void PlusButton(string cashierName, int productId)
        {
            IEnumerable<Transaction> transactions = GetByDay(cashierName, DateTime.Today);
            var transaction = transactions.FirstOrDefault(x => x.ProductID == productId);
            var product = productRepository.GetProductByID(productId);
            product.Quantity--;
            transaction.SoldQty++;
            transaction.BeforeQty = product.Quantity.Value;
            db.Transactions.Update(transaction);
            db.SaveChanges();
        }

        public void DeleteTransaction(string cashierName, int productId)
        {
            IEnumerable<Transaction> transactions = GetByDay(cashierName, DateTime.Today);
            var transaction = transactions.FirstOrDefault(x => x.ProductID == productId);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
        }


        public void Save(string cashierName, int productId, string productName, double price, double beforeQty, double soldQty, string unit)
        {
            var transaction = db.Transactions.FirstOrDefault(f=>f.ProductID == productId && f.TimeStamp == DateTime.Today);
            if (transaction == null)
            {
                transaction = new Transaction
                {
                    ProductID = productId,
                    ProductName = productName,
                    TimeStamp = DateTime.Today,
                    Price = price,
                    BeforeQty = beforeQty,
                    SoldQty = soldQty,
                    Unit = unit,
                    CashierName = cashierName
                };
                db.Transactions.Add(transaction);
            }
            else
            {
                transaction.BeforeQty -= soldQty;
                transaction.SoldQty += soldQty;
                db.Transactions.Update(transaction);
            }
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
