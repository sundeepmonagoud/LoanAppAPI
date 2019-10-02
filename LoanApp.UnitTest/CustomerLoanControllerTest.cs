using AutoMapper;
using LoanApp.BAL;
using LoanApp.BAL.DataObjects;
using LoanApp.WebAPI.Controllers;
using LoanApp.WebAPI.Mapper;
using LoanApp.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net.Http;

namespace LoanApp.UnitTest
{
    [TestClass]
    public class CustomerLoanControllerTest
    {
        [TestMethod]
        public void GetCustomerLoansTest()
        {

            var mockRepo = new Mock<ICustomerLoanServiceBAL>();
            mockRepo.Setup(repo => repo.GetCustomerLoans())
                .Returns(GetTestCustLoans());

            //var mapperMock = new Mock<IMapper>();
            //mapperMock.Setup(m => m.Map<CustomerLoanModel, CustomerLoanData>(It.IsAny<CustomerLoanModel>())).Returns(CustomerLoanData);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>(); 
            });

            var mapper = config.CreateMapper();

            var controller = new CustomerLoanController(mapper, mockRepo.Object);

            var result = controller.GetCustomerLoans();


            Assert.IsNotNull(result.Value);

           Assert.IsInstanceOfType(result.Value, typeof(IEnumerable<CustomerLoanModel>));

            var custloans = (IEnumerable<CustomerLoanModel>)  result.Value;
 
        }

        #region snippet_GetTestSessions
        private IEnumerable<CustomerLoanData> GetTestCustLoans()
        {
            var custLoans = new List<CustomerLoanData>();
            custLoans.Add(new CustomerLoanData()
            {
                LoanId = 123,
                Balance = 300,
                EarlyRePaymentFee = 100,
                Interest = 50,
                LoanNumber = 12341234,
                Name = "Personal Loan1",
                PayoutAmount = 450
               
            });
            custLoans.Add(new CustomerLoanData()
            {
                LoanId = 323,
                Balance = 400,
                EarlyRePaymentFee = 150,
                Interest = 50,
                LoanNumber = 353453,
                Name = "Home Loan",
                PayoutAmount = 600

            });

            return custLoans;
        }
        #endregion
    }
}
