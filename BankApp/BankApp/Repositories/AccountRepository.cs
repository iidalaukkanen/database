using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    class AccountRepository : IAccountRepository
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void CreateAccount(Account account)
        {
            _bankdbContext.Account.Add(account);
            _bankdbContext.SaveChanges();
            Console.WriteLine("Tili lisätty onnistuneesti tietokantaan!");
        }

        public void DeleteAccount(string iban)
        {
            var deletedAccount = Read(iban);
            if (deletedAccount != null)
            {
                _bankdbContext.Account.Remove(deletedAccount);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Tili poistettu onnistuneesti!");
            }

            else
                Console.WriteLine("Tilin poisto epäonnistui! - Tiliä ei löydy.");
        }

        public Account Read(string iban)
        {
            var account = _bankdbContext.Account
                .FirstOrDefault(a => a.Iban == iban);
            return account;
        }

        public List<Account> ReadAccounts(Customer customer)
        {
            var accounts = _bankdbContext.Account.Where(c => c.CustomerId == customer.Id)
                .Include(t => t.Transaction).ToList();
            return accounts;
        }
    }
}
