using LoanApp.BAL.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanApp.BAL
{
    public interface ICustomerLoanServiceBAL
    {
        IEnumerable<CustomerLoanData> GetCustomerLoans();
    }
}
