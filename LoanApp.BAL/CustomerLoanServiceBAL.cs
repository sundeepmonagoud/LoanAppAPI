using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoanApp.BAL.DataObjects;
using LoanApp.DAL;

namespace LoanApp.BAL
{
    public class CustomerLoanServiceBAL : ICustomerLoanServiceBAL
    {
        ICustomerLoanServiceDAL _customerServiceDAL;
        ILoanServiceDAL _loanServiceDAL;
        public CustomerLoanServiceBAL(ILoanServiceDAL loanServiceDAL, ICustomerLoanServiceDAL customerServiceDAL)
        {
            _loanServiceDAL = loanServiceDAL;
            _customerServiceDAL = customerServiceDAL;
        }

        public IEnumerable<CustomerLoanData> GetCustomerLoans()
        {
            return _customerServiceDAL.GetCustomerLoanDetails().Join(_loanServiceDAL.GetLoanDetails(), cl => cl.LoanId, ld => ld.Id, (cl, ld) => new { cl, ld })
                  .Select(cld => new CustomerLoanData()
                  {
                      LoanId = cld.cl.LoanId,
                      LoanNumber = cld.cl.LoanNumber,
                      Balance = Convert.ToDecimal(cld.cl.Balance),
                      Interest = Convert.ToDecimal(cld.cl.Interest),

                      EarlyRePaymentFee = Convert.ToDecimal(cld.cl.EarlyRePaymentFee),
                      PayoutAmount = Convert.ToDecimal(cld.cl.Balance) + Convert.ToDecimal(cld.cl.Interest) + Convert.ToDecimal(cld.cl.EarlyRePaymentFee),
                      Name = cld.ld.Name
                  }
                  ).ToList();

        }
    }
}
