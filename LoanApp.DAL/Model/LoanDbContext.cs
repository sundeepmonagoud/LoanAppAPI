using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LoanApp.DAL.Model
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> dbContextOptions): base(dbContextOptions)
        {

        }

        public DbSet<LoanDetails> LoanDetails { get; set; }
        public DbSet<CustomerLoanDetails> CustomerLoanDetails { get; set; }

    }
}
