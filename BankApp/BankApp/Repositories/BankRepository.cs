﻿using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    class BankRepository : IBankRepository
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void CreateBank(Bank bank)
        {
            _bankdbContext.Bank.Add(bank);
            _bankdbContext.SaveChanges();
            Console.WriteLine("Uuden pankin luominen onnistui!");
        }

        public void DeleteBank(long id)
        {
            var deleteBank = ReadBank(id);
            if (deleteBank != null)
            {
                _bankdbContext.Bank.Remove(deleteBank);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti!");
            }

            else
                Console.WriteLine("Tiedon poisto EI onnistunut - ID tuntematon.");
        }

        public Bank ReadBank(long id)
        {
            var bank = _bankdbContext.Bank.
                FirstOrDefault(b => b.Id == id);

            return bank;
        }

        public List<Bank> ReadBanks()
        {
            var banks = _bankdbContext.Bank.Include(b => b.Customer).ToList();
            return banks;
        }

        public void UpdateBank(long id, Bank bank)
        { 
                _bankdbContext.Update(bank);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Tietojen päivitys onnistui!");
           
        }
    }
}
