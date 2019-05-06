using System;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp
{
    class Program
    {
        static private BankRepository _bankRepository = new BankRepository();
        static private CustomerRepository _customerRepository = new CustomerRepository();
        static private AccountRepository _accountRepository = new AccountRepository();
        static private TransactionRepository _TransactionRepository = new TransactionRepository();

        static void Main(string[] args)
        {
            var banks = _bankRepository.ReadBanks();

            foreach (var b in banks)
            {
                Console.Write(b.Name + " ");
            }
        }
    }
}
