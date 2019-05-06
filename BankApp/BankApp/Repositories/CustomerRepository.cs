using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        public void CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }

        public Customer Read(long id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> ReadCustomers()
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(long id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
