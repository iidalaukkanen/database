using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.Views
{
    class UIModelBank
    {
        private static readonly BankRepository _bankRepository = new BankRepository();

        private static readonly TransactionRepository _transactionsRepository = new TransactionRepository();

        public void CreateBank()
        {
            Bank bank = new Bank
            {
                Name = "OmaSP",
                Bic = "ITELFIHH"
            };

            _bankRepository.CreateBank(bank);
        }
        
        public void DeleteBank(long id)
        {
            _bankRepository.DeleteBank(id);
        }

        public void UpdateBank()
        {
            long id;
            Console.WriteLine("Jos haluat päivittää pankin tiedot, syötä sen ID:");
            while (!long.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Väärä syöte! Kirjoita numero.");
            }

            var isBankOk = _bankRepository.ReadBank(id);
            if (isBankOk != null)
            {
                Bank updateBank = _bankRepository.ReadBank(id);
                updateBank.Name = "OP";
                updateBank.Bic = "OKOYFIHH";
                _bankRepository.UpdateBank(id, updateBank);
            }
            else
                Console.WriteLine("Tietojen päivitys epäonnistui! - Kyseistä pankkia ei löydy.");

        }

        public void PrintBanks()
        {
            var banks = _bankRepository.ReadBanks();

            foreach(var b in banks)
            {
                Console.WriteLine("Pankki:  " + b.Name.PadRight(15) + "|\tBIC:    " + b.Bic);
            }
        }
        
    }
}
