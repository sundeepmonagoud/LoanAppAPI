using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.WebAPI.Model
{
    public class CustomerLoanModel
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
