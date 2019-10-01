using System;
using System.Collections.Generic;
using System.Text;

namespace LoanApp.BAL.DataObjects
{
    public class CustomerLoanData
    {
        public long LoanId { get; set; }
        public long LoanNumber { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Interest { get; set; }
        public decimal EarlyRePaymentFee { get; set; }
        public decimal PayoutAmount { get; set; }
    }
}
