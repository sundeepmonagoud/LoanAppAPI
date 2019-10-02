using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanApp.DAL.Model
{
    public  class LoanDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set;  }
        public DateTime? ModifiedDate { get; set; }

        public  List<CustomerLoanDetails> CustomerLoanDetails { get; set; }
    }
}
