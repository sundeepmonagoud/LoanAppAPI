using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoanApp.BAL;
using LoanApp.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerLoanController : ControllerBase
    {
        ICustomerLoanServiceBAL _customerServiceBAL;
        IMapper _mapper;
        public CustomerLoanController(IMapper mapper, ICustomerLoanServiceBAL customerServiceBAL)
        {
            _customerServiceBAL = customerServiceBAL;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerLoanModel>> GetCustomerLoans()
        {
            try
            {
              var customerData =  _customerServiceBAL.GetCustomerLoans();
              var customerModel  = _mapper.Map<IEnumerable<CustomerLoanModel>>(customerData);

                return new ActionResult<IEnumerable<CustomerLoanModel>>(customerModel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}