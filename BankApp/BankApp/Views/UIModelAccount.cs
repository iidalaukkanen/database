using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;
using System.Linq;
using System.Globalization;
    

namespace BankApp.Views
{
    class UIModelAccount
    {
        private static readonly AccountRepository _accountRepository = new AccountRepository();
        private static readonly CustomerRepository _customerRepository = new CustomerRepository();
        private static readonly TransactionRepository _transactionRepository = new TransactionRepository();

        Customer customer = _customerRepository.ReadCustomers()
            .FirstOrDefault(name => name.Firstname == "Matti");

        public void CreateAccount()
        {
            Account account = new Account()
            {
                Iban = "FI1234123412341239",
                BankId = 4,
                CustomerId = customer.Id,
                Balance = 9000
            };

            _accountRepository.CreateAccount(account);
        }

        public void DeleteAccount()
        {
            _accountRepository.DeleteAccount("FI098765432187654321");
        }

        public void PrintAccounts()
        {
            Console.WriteLine("Tilin haltija:\t" + customer.Firstname + " " + customer.Lastname);
            var accounts = _accountRepository.ReadAccounts(customer);
            foreach (var a in accounts)
            {
                Console.WriteLine("Iban:\t\t" + a.Iban);
                Console.WriteLine("Saldo:\t\t" + a.Balance.ToString("c", CultureInfo.CurrentCulture));
                Console.Write("Tilitapahtumat:  ");
                foreach (var t in a.Transaction)
                {
                    Console.WriteLine(t.TimeStamp + " " + t.Amount.ToString("c", CultureInfo.CurrentCulture));
                }

                Console.WriteLine("\n_________________________________________________\n");
            }
        }

        public void CreateTransaction()
        {
            Transaction transaction = new Transaction()
            {
                Amount = 911,
                Iban = "FI1234123412341239",
                TimeStamp = DateTime.Now
            };

            _transactionRepository.CreateTransaction(transaction);                
        }
    }
}
