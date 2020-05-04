using Data.Interfaces;
using Data.Model;
using Data.Repositories;
using Logic.Dto;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Logic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IdGenerator _idGenerator;
        private readonly IRepository<Customer> _customerRepository;
        private readonly object m_SyncObject = new object();


        public CustomerService()
        {
            _idGenerator = new IdGenerator();
            _customerRepository = new CustomerRepository();
        }

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _idGenerator = new IdGenerator();
            _customerRepository = customerRepository;
        }

        public CustomerDto GetCustomer(string id)
        {
            lock (m_SyncObject) //komunikacja sieciowa
            {
                Customer customer = _customerRepository.Get(id);
                return customer.ToDto();
            }
        }

        public void SaveCustomer(CustomerDto customer)
        {
            if (string.IsNullOrEmpty(customer.Id))
            {
                string newCustomerId = _idGenerator.GetNextCustomerId();
                customer.Id = newCustomerId;
                Customer customerToSave = customer.FromDto();
                _customerRepository.Add(customerToSave);
            }
            else
            {
                Customer customerToSave = customer.FromDto();
                _customerRepository.Add(customerToSave);
            }
        }
    }
}
