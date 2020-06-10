using ServerData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerData
{
    public class DataContext
    {
        private Dictionary<string, Customer> _customers;
        private Dictionary<string, Merchandise> _merchandises;
        private Dictionary<string, Order> _orders;

        public Dictionary<string, Customer> Customers { get => _customers; set => _customers = value; }
        public Dictionary<string, Merchandise> Merchandises { get => _merchandises; set => _merchandises = value; }
        public Dictionary<string, Order> Orders { get => _orders; set => _orders = value; }

        public DataContext()
        {
            _customers = new Dictionary<string, Customer>();
            _merchandises = new Dictionary<string, Merchandise>();
            _orders = new Dictionary<string, Order>();
        }

        public DataContext(Dictionary<string, Customer> clients, Dictionary<string, Merchandise> merchandises, Dictionary<string, Order> orders)
        {
            _customers = clients;
            _merchandises = merchandises;
            _orders = orders;
        }
    }
}
