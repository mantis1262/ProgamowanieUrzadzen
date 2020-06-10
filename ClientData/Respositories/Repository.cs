using ClientData.Interfaces;
using ClientData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientData.Respositories
{
    public class Repository : IRepository
    {
        private readonly DataContext _dataContext;
        private readonly object m_SyncObject = new object();

        public Repository()
        {
            _dataContext = new DataContext();
        }

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Customer GetCurrentCustomer()
        {
            return _dataContext.CurrentCustomer;
        }

        public IList<Merchandise> GetMerchandises()
        {
            return _dataContext.Merchandises;
        }

        public Order GetCurrentOrder()
        {
            return _dataContext.CurrentOrder;
        }

        public void RefreshCurrentCustomer(Customer customer)
        {
            lock(m_SyncObject)
            {
                _dataContext.CurrentCustomer = customer;
            }
        }

        public void RefreshMerchandises(IList<Merchandise> merchandises)
        {
            lock(m_SyncObject)
            {
                _dataContext.Merchandises = merchandises;
            }
        }

        public void RefreshCurrentOrder(Order order)
        {
            lock(m_SyncObject)
            {
                _dataContext.CurrentOrder = order;
            }
        }
    }
}
