using AutoMapper;
using LoanApp.BAL.DataObjects;
using LoanApp.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.WebAPI.Mapper
{
    public class AutoMapperProfile : Profile
    {
       
       public AutoMapperProfile()
        {
            CreateMap <CustomerLoanModel, CustomerLoanData> ().ReverseMap();
        }
    }
}
