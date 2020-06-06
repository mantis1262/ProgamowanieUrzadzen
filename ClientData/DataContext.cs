using ClientData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientData
{
    public class DataContext
    {
        private Customer _currentCustomer;
        private IList<Merchandise> _merchandises;
        private Order _currentOrder;

        public Customer CurrentCustomer { get => _currentCustomer; set => _currentCustomer = value; }
        public IList<Merchandise> Merchandises { get => _merchandises; set => _merchandises = value; }
        public Order CurrentOrder { get => _currentOrder; set => _currentOrder = value; }

        public DataContext()
        {
            _currentCustomer = new Customer();
            _merchandises = new List<Merchandise>();
            _currentOrder = new Order();
        }

        public DataContext(Customer currentCustomer, IList<Merchandise> merchandises, Order currentOrder)
        {
            _currentCustomer = currentCustomer;
            _merchandises = merchandises;
            _currentOrder = currentOrder;
        }
    }
}
