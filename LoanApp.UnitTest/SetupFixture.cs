using AutoMapper;
using LoanApp.BAL;
using LoanApp.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanApp.UnitTest
{
    [TestClass]
    public static class SetupFixture
    {
        internal static string ConnectionString;

        internal static IMapper Mapper;
      

        internal static ICustomerLoanServiceBAL CustomerLoanServiceBAL;
        internal static ICustomerLoanServiceDAL CustomerLoanServiceDAL;
        internal static ILoanServiceDAL LoanServiceDAL;
    }
}
