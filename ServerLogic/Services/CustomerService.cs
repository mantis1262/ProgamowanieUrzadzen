using ServerData.Interfaces;
using ServerData.Model;
using ServerData.Repositories;
using ServerLogic.Dto;
using ServerLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly object m_SyncObject = new object();

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> GetCustomer(string id)
        {
            Customer customer = await Task.Factory.StartNew(() => _customerRepository.Get(id));
            if (customer != null)
                return customer.ToDto();
            else return null;
        }

        public async Task<string> SaveCustomer(CustomerDto customer)
        {
            await Task.Factory.StartNew(() => 
            {
                lock (m_SyncObject)
                {
                    if (string.IsNullOrEmpty(customer.Id))
                    {
                        string newCustomerId = IdGenerator.GetNextCustomerId();
                        customer.Id = newCustomerId;
                        Customer customerToSave = customer.FromDto();
                        _customerRepository.Add(customerToSave);
                    }
                    else
                    {
                        Customer customerToSave = customer.FromDto();
                        _customerRepository.Update(customer.Id, customerToSave);
                    }
                }

            });
            return customer.Id;
        }
    }
}
