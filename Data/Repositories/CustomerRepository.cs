using Data.Interfaces;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly DataContext _dataContext;

        public CustomerRepository()
        {
            _dataContext = new DataContext();
        }
        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public CustomerRepository(DataContext dataContext, IDataFiller dataFiller)
        {
            _dataContext = dataContext;
            dataFiller.Fill(_dataContext);
        }

        public IEnumerable<Customer> Get()
        {
            return _dataContext.Customers.Values;
        }

        public Customer Get(string id)
        {
            _dataContext.Customers.TryGetValue(id, out Customer client);
            return client;
        }

        public void Add(Customer entity)
        {
            if (!_dataContext.Customers.ContainsKey(entity.Id))
            {
                _dataContext.Customers.Add(entity.Id, entity);
            }
            else
            {
                throw new Exception("You're trying to add the existing client with id: " + entity.Id);
            }
        }

        public void Delete(string id)
        {
            if (_dataContext.Customers.ContainsKey(id))
            {
                _dataContext.Customers.Remove(id);
            }
            else
            {
                throw new Exception("You're trying to delete client with non-existing id.");
            }
        }

        public void Update(string id, Customer entity)
        {
            Customer client = Get(id);
            if (client != null)
            {
                client.Name = entity.Name;
                client.Address = entity.Address;
                client.PhoneNumber = entity.PhoneNumber;
                client.Nip = entity.Nip;
                client.Pesel = entity.Pesel;
            }
            else
            {
                throw new Exception("You're trying to update client with non-existing id.");
            }
        }
    }
}
