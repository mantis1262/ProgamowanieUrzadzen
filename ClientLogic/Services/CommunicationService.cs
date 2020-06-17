using ClientData.Communication;
using ClientData.Interfaces;
using ClientData.Model;
using ClientLogic.Dto;
using ClientLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace ClientLogic.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly WebSocketController _webSocketController;
        private Uri _uri;

        public CommunicationService(IRepository repository, Action<string> logger, string uri, ISubject<string> messageChain)
        {
            _webSocketController = new WebSocketController(repository, logger, messageChain);
            _uri = new Uri(uri);
        }

        public async Task<ClientWebSocketConnection> CreateConnection()
        {
            return await _webSocketController.Connect(_uri);
        }

        public async Task<Customer> AskForCustomer(string customerId)
        {
            return await _webSocketController.GetCustomerRequest(customerId);
        }

        public async Task<IList<Merchandise>> AskForMerchandises()
        {
            return await _webSocketController.GetMerchandisesRequest();
        }

        public async Task<Order> AskForOrder(string orderId)
        {
            return await _webSocketController.GetOrderRequest(orderId);
        }

        public async Task<string> ApplyOrder(OrderDto order)
        {
            return await _webSocketController.MakeOrderRequest(order.FromDto());
        }

        public async Task<string> AskForSubscription()
        {
            return await _webSocketController.SubscribeDiscount();
        }

        public async Task<string> AskForUnsubscription()
        {
            return await _webSocketController.UnsubscribeDiscount();
        }
    }
}
