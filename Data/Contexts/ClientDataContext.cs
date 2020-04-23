using Data.Api;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contexts
{
    public class ClientDataContext : ClientDataLayer
    {
        private Order _order;

        public Order GetOrder(string id)
        {
            // TODO with network
            return _order;
        }

        public string SendOrder(Order order)
        {
            // TODO with network
            _order = order;
            return _order.Id;
        }

        public void ConfirmDelivery(string id, DateTime dateTime)
        {
            // TODO with network
            _order.DeliveringDate = dateTime;
        }
    }
}
