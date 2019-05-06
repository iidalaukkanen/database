using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.Repositories
{
    class AccountRepository : IAccountRepository
    {
        public void CreateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(string iban)
        {
            throw new NotImplementedException();
        }

        public Account Read(string iban)
        {
            throw new NotImplementedException();
        }

        public List<Account> ReadAccounts(Bank bank)
        {
            throw new NotImplementedException();
        }
    }
}
