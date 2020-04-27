using Data.Contexts;
using Data.Model;
using Data.Api;
using Logic.Api;
using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Contexts
{
    public class ClientLogicContext : ClientLogicLayer
    {
        private ClientDataLayer _clientDataContext;

        public ClientLogicContext()
        {
            _clientDataContext = new ClientDataContext();
        }

        public ClientLogicContext(ClientDataLayer clientDataContext)
        {
            _clientDataContext = clientDataContext;
        }

        public ClientDto GetClient(string id)
        {
            return _clientDataContext.GetClientInfo(id).ToDto();
        }

        public List<MerchandiseDto> GetMerchandises()
        {
            return _clientDataContext.GetMerchandises().ToDto();
        }

        public OrderDto GetOrder(string id)
        {
            return _clientDataContext.GetOrder(id).ToDto();
        }

        public string SubmitOrder(OrderDto orderDto)
        {
            string result = _clientDataContext.SubmitOrder(orderDto.FromDto());

            return result;
        }

        public string ConfirmDelivery(string id, DateTime dateTime)
        {
            string result = _clientDataContext.ConfirmDelivery(id, dateTime);

            return result;
        }
    }
}
