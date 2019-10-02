using LoanApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanApp.DAL
{
    public interface ICustomerLoanServiceDAL
    {
        IQueryable<CustomerLoanDetails> GetCustomerLoanDetails();
    }
}
