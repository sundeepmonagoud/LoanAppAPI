using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoanApp.DAL.Model;

namespace LoanApp.DAL
{
    public class LoanServiceDAL : ILoanServiceDAL
    {
        LoanDbContext _loanDbContext;

        public LoanServiceDAL(LoanDbContext loanDbContext)
        {
            _loanDbContext = loanDbContext;
        }

        public IQueryable<LoanDetails> GetLoanDetails()
        {
            return _loanDbContext.LoanDetails.AsQueryable();
        }
    }
}
