using Data.Api;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contexts
{
    public class ServerDataContext : ServerDataLayer
    {
        private Dictionary<string, Order> _orders;

        public ServerDataContext()
        {
            _orders = new Dictionary<string, Order>();
        }

        public Order GetOrder(string id)
        {
            _orders.TryGetValue(id, out Order order);

            if (order == null)
            {
                throw new KeyNotFoundException("Order not found !");
            }

            return order;
        }

        public string SaveOrder(Order order)
        {
            _orders.Add(order.Id, order);

            return order.Id;
        }

        public void ModifyOrder(Order order)
        {
            _orders.TryGetValue(order.Id, out Order existingOrder);

            if (existingOrder == null)
            {
                throw new KeyNotFoundException("Order not found !");
            }

            _orders.Remove(order.Id);
            _orders.Add(order.Id, order);
        }
    }
}
