using Data.Interfaces;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly DataContext _dataContext;

        public OrderRepository()
        {
            _dataContext = new DataContext();
        }

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public OrderRepository(DataContext dataContext, IDataFiller dataFiller)
        {
            _dataContext = dataContext;
            dataFiller.Fill(_dataContext);
        }

        public IEnumerable<Order> Get()
        {
            return _dataContext.Orders.Values;
        }

        public Order Get(string id)
        {
            _dataContext.Orders.TryGetValue(id, out Order order);
            return order;
        }

        public void Add(Order entity)
        {
            if (!_dataContext.Orders.ContainsKey(entity.Id))
            {
                _dataContext.Orders.Add(entity.Id, entity);
            }
            else
            {
                throw new Exception("You're trying to add the existing order with id: " + entity.Id);
            }
        }

        public void Delete(string id)
        {
            if (_dataContext.Orders.ContainsKey(id))
            {
                _dataContext.Orders.Remove(id);
            }
            else
            {
                throw new Exception("You're trying to delete order with non-existing id.");
            }
        }

        public void Update(string id, Order entity)
        {
            Order order = Get(id);
            order.Client = entity.Client;
            order.Entries = entity.Entries;
            order.Status = entity.Status;
            order.AcceptanceDate = entity.AcceptanceDate;
            order.DeliveringDate = entity.DeliveringDate;
        }
    }
}
