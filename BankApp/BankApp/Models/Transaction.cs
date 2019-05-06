using System;
using System.Collections.Generic;

namespace BankApp.Models
{
    public partial class Transaction
    {
        public long Id { get; set; }
        public string Iban { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual Account IbanNavigation { get; set; }
    }
}