using ClientData.Communication;
using ClientData.Interfaces;
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

        public async Task CreateConnection()
        {
            await _webSocketController.Connect(_uri);
        }

        public async Task AskForCustomer(string customerId)
        {
            await _webSocketController.GetCustomerRequest(customerId);
        }

        public async Task AskForMerchandises()
        {
            await _webSocketController.GetMerchandisesRequest();
        }

        public async Task AskForOrder(string orderId)
        {
            await _webSocketController.GetOrderRequest(orderId);
        }

        public async Task ApplyOrder(OrderDto order)
        {
            await _webSocketController.MakeOrderRequest(order.FromDto());
        }

        public async Task AskForSubscription()
        {
            await _webSocketController.SubscribeDiscount();
        }

        public async Task AskForUnsubscription()
        {
            await _webSocketController.UnsubscribeDiscount();
        }
    }
}
