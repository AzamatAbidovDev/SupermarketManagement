using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public double BeforeQty { get; set; }
        public double SoldQty { get; set; }
        public string CashierName { get; set; }
    }
}
