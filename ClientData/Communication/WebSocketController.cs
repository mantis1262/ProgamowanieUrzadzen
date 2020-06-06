using ClientData.Interfaces;
using ClientData.Model;
using Communication.Model;
using Communication.Requests;
using Communication.Responses;
using Newtonsoft.Json;
using ServerPresentation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace ClientData.Communication
{
    public class WebSocketController
    {
        private ClientWebSocketConnection _clientWebSocket;
        private IRepository _repository;
        private Action<string> _log;
        private ISubject<string> _messageChain;

        public WebSocketController(IRepository repository, Action<string> logger, ISubject<string> mesgChain)
        {
            _repository = repository;
            _log = logger;
            _messageChain = mesgChain;
        }

        public async Task Connect(Uri peer)
        {
            _clientWebSocket = (ClientWebSocketConnection)await WebSocketClient.Connect(peer, _log);
            _clientWebSocket.OnMessage = message => OnInvokeMessage(message);
        }

        public async Task SendMessage(string message)
        {
            await _clientWebSocket.SendAsync(message);
        }

        private void OnInvokeMessage(string message)
        {
            Task.Factory.StartNew(async () => await ProcessMessage(message));  
        }

        #region Requests
        public async Task GetCustomerRequest(string customerId)
        {
            GetCustomerRequest request = new GetCustomerRequest("get_customer", customerId);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _clientWebSocket.SendAsync(requestJson);
        }

        public async Task GetMerchandisesRequest()
        {
            GetMerchandisesRequest request = new GetMerchandisesRequest("get_merchandises");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _clientWebSocket.SendAsync(requestJson);
        }

        public async Task GetOrderRequest(string orderId)
        {
            GetOrderRequest request = new GetOrderRequest("get_order", orderId);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _clientWebSocket.SendAsync(requestJson);
        }

        public async Task MakeOrderRequest(Order order)
        {
            OrderModel orderModel = order.ToCommModel();
            OrderRequestResponse request = new OrderRequestResponse("make_order", orderModel);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _clientWebSocket.SendAsync(requestJson);
        }

        public async Task SubscribeDiscount()
        {
            WebMessageBase request = new WebMessageBase("subscription");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _clientWebSocket.SendAsync(requestJson);
        }

        public async Task UnsubscribeDiscount()
        {
            WebMessageBase request = new WebMessageBase("unsubscription");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _clientWebSocket.SendAsync(requestJson);
        }
        #endregion

        #region MessagesProcessing
        private async Task ProcessMessage(string message)
        {
            try
            {
                WebMessageBase request = JsonConvert.DeserializeObject<WebMessageBase>(message);
                Debug.WriteLine("[{0}] Client received response: {1} , status: {2}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag, request.Status);
                string outp = String.Empty;

                if (request.Status == MessageStatus.FAIL)
                {
                    _log(request.Message);
                    return;
                }

                switch (request.Tag)
                {
                    case "connection_established":
                        {
                            await Task.Factory.StartNew(() => ProcessConnectionResponse());
                            break;
                        }
                    case "get_customer":
                        {
                            await ProcessGetCustomerResponse(message);
                            break;
                        }
                    case "get_merchandises":
                        {
                            await ProcessGetMerchandiseResponse(message);
                            break;
                        }
                    case "get_order":
                        {
                            await  ProcessGetOrderResponse(message);
                            break;
                        }
                    case "make_order":
                        {
                            await Task.Factory.StartNew(() => ProcessSaveOrderResponse(message));
                            break;
                        }
                    case "subscription":
                        {
                            await Task.Factory.StartNew(() => ProcessSubscribeResponse());
                            break;
                        }
                    case "unsubscription":
                        {
                            await Task.Factory.StartNew(() => ProcessUnsubscribeResponse());
                            break;
                        }
                    case "discount":
                        {
                            await ProcessDiscountMessage(message);
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                _log("Error: " + e.Message);
            }
        }

        private void ProcessConnectionResponse()
        {
            _messageChain.OnNext("connection_established");
        }

        private async Task ProcessGetCustomerResponse(string message)
        {
            GetCustomerResponse response = JsonConvert.DeserializeObject<GetCustomerResponse>(message);
            CustomerModel customerModel = response.Customer; 
            await Task.Factory.StartNew(() => _repository.RefreshCurrentCustomer(customerModel.FromCommModel()));
            _messageChain.OnNext("get_customer");
        }

        private async Task ProcessGetMerchandiseResponse(string message)
        {
            GetMerchandisesResponse response = JsonConvert.DeserializeObject<GetMerchandisesResponse>(message);
            List<MerchandiseModel> merchandisesModels = response.Merchandises;
            List<Merchandise> products = merchandisesModels.FromCommModel();
            await Task.Factory.StartNew(() => _repository.RefreshMerchandises(products));
            _messageChain.OnNext("get_merchandises");
        }

        private async Task ProcessGetOrderResponse(string message)
        {
            OrderRequestResponse response = JsonConvert.DeserializeObject<OrderRequestResponse>(message);
            Customer customer = response.Order.ClientInfo.FromCommModel();
            Order order = response.Order.FromCommModel();
            await Task.Factory.StartNew(() => _repository.RefreshCurrentOrder(order));
            _messageChain.OnNext("get_order");
        }

        private void ProcessSaveOrderResponse(string message)
        {
            OrderRequestResponse response = JsonConvert.DeserializeObject<OrderRequestResponse>(message);
            string clientId = response.Order.ClientInfo.Id;
            string orderId = response.Order.Id;
            _messageChain.OnNext("make_order:" + clientId + ":" + orderId);
        }

        private void ProcessSubscribeResponse()
        {
            
        }

        private void ProcessUnsubscribeResponse()
        {
            
        }

        private async Task ProcessDiscountMessage(string message)
        {
            SubscriptionMessage response = JsonConvert.DeserializeObject<SubscriptionMessage>(message);
            double discount = response.discountData.Discount;
            List<Merchandise> responseProducts = response.discountData.Merchandises.FromCommModel();
            await Task.Factory.StartNew(() => _repository.RefreshMerchandises(responseProducts));
        }
        #endregion
    }
}
