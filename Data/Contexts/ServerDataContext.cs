using Data.Api;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Contexts
{
    public class ServerDataContext : ServerDataLayer
    {
        private Dictionary<string, ClientContactInfo> _clients;
        private Dictionary<string, Merchandise> _merchandises;
        private Dictionary<string, Order> _orders;

        public ServerDataContext()
        {
            _merchandises = new Dictionary<string, Merchandise>();
            _orders = new Dictionary<string, Order>();
        }

        public ServerDataContext(Dictionary<string, Merchandise> merchandises, Dictionary<string, Order> orders)
        {
            _merchandises = merchandises;
            _orders = orders;
        }

        public ClientContactInfo SendClientInfo(string id)
        {
            _clients.TryGetValue(id, out ClientContactInfo client);

            if (client == null)
            {
                throw new KeyNotFoundException("Client not found !");
            }

            return client;
        }

        public List<Merchandise> SendMerchandises()
        {
            return _merchandises.Values.ToList();
        }

        public Order SendOrder(string id)
        {
            _orders.TryGetValue(id, out Order order);

            if (order == null)
            {
                throw new KeyNotFoundException("Order not found !");
            }

            return order;
        }

        public string SaveClientInfo(ClientContactInfo client)
        {
            _clients.Add(client.Id, client);

            return client.Id;
        }

        public string SaveOrder(Order order)
        {
            _orders.Add(order.Id, order);

            return order.Id;
        }

        public string CloseOrder(string id, DateTime dateTime)
        {
            _orders.TryGetValue(id, out Order existingOrder);

            if (existingOrder == null)
            {
                throw new KeyNotFoundException("Order not found !");
            }

            existingOrder.DeliveringDate = dateTime;
            string result = id + " " + dateTime.ToString();
            return result;
        }

        public void SendStatsOfDay(DailyStats dailyStats)
        {
            // TODO with network
        }
    }
}
