using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoanApp.DAL.Model;

namespace LoanApp.DAL
{
    public class CustomerLoanServiceDAL : ICustomerLoanServiceDAL
    {
        LoanDbContext _loanDbContext;
        public CustomerLoanServiceDAL(LoanDbContext loanDbContext)
        {
            _loanDbContext = loanDbContext;
        }

        public IQueryable<CustomerLoanDetails> GetCustomerLoanDetails()
        {
            return _loanDbContext.CustomerLoanDetails.AsQueryable();
        }
    }
}
