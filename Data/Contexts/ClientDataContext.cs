using Data.Api;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contexts
{
    public class ClientDataContext : ClientDataLayer
    {
        private ClientContactInfo _clientInfo;
        private List<Merchandise> _merchandises;
        private Order _order;

        public ClientDataContext()
        {
        }

        public ClientDataContext(ClientContactInfo clientInfo, Order order)
        {
            _clientInfo = clientInfo;
            _order = order;
        }

        public ClientContactInfo GetClientInfo(string id)
        {
            // TODO with network
            return _clientInfo;
        }

        public List<Merchandise> GetMerchandises()
        {
            // TODO with network
            return _merchandises;
        }

        public Order GetOrder(string id)
        {
            // TODO with network
            return _order;
        }

        public string SubmitOrder(Order order)
        {
            // TODO with network
            _order = order;
            return _order.Id;
        }

        public string ConfirmDelivery(string id, DateTime dateTime)
        {
            // TODO with network
            _order.DeliveringDate = dateTime;
            string result = id + " " + dateTime.ToString();
            return result;
        }
    }
}
