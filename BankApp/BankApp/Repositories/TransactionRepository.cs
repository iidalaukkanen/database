using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.Repositories
{
    class TransactionRepository : ITransactionRepository
    {
        public void CreateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> ReadTransactions()
        {
            throw new NotImplementedException();
        }
    }
}
