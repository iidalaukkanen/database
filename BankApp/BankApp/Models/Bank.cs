using System;
using System.Collections.Generic;

namespace BankApp.Models
{
    public partial class Bank
    {
        public Bank()
        {
            Account = new HashSet<Account>();
            Customer = new HashSet<Customer>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Bic { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
    }
}