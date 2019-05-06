using System;
using System.Collections.Generic;

namespace BankApp.Models
{
    public partial class Account
    {
        public Account()
        {
            Transaction = new HashSet<Transaction>();
        }

        public string Iban { get; set; }
        public string Name { get; set; }
        public long BankId { get; set; }
        public long CustomerId { get; set; }
        public decimal Balance { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}