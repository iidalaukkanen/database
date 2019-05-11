using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void CreateCustomer(Customer customer)
        {
            _bankdbContext.Customer.Add(customer);
            _bankdbContext.SaveChanges();
            Console.WriteLine("Asiakas lisätty tietokantaan onnistuneesti!");
        }

        public void DeleteCustomer(long id)
        {
            var deletedCustomer = Read(id);
            if (deletedCustomer != null)
            {
                _bankdbContext.Customer.Remove(deletedCustomer);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti!");
            }
            else
            {
                Console.WriteLine("Tiedon poisto EI onnistunut - ID tuntematon");
            }
        }

        public Customer Read(long id)
        {
            var customer = _bankdbContext.Customer
                .FirstOrDefault(p => p.Id == id);

            return customer;
        }

        public List<Customer> ReadCustomers()
        {
            var customers = _bankdbContext.Customer.ToList();
            return customers;
        }

        public void UpdateCustomer(long id, Customer customer)
        {
            var isCustomerOk = Read(id);
            if (isCustomerOk != null)
            {
                _bankdbContext.Update(customer);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Tietojen päivitys onnistui!");
            }
            else
            {
                Console.WriteLine("Tietojen päivitys epäonnistui! - Asiakasta ei ole olemassa.");
            }
        }
    }
}
