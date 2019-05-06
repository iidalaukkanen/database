using System;
using System.Collections.Generic;

namespace BankApp.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Account = new HashSet<Account>();
        }

        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long BankId { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual ICollection<Account> Account { get; set; }
    }
}