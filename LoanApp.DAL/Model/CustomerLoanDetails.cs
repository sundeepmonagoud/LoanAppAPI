using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanApp.DAL.Model
{
    public class CustomerLoanDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; } 
        public long LoanNumber { get; set; }
        public long LoanId { get; set; }
        public decimal? Balance { get; set; }
        public decimal? Interest { get; set; }
        public decimal? EarlyRePaymentFee { get; set; }
        public decimal? PayoutAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public LoanDetails LoanDetails { get; set; }
    }
}
