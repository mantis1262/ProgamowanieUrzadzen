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
using System.Net.WebSockets;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
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

        public async Task<ClientWebSocketConnection> Connect(Uri peer)
        {
            _clientWebSocket = (ClientWebSocketConnection)await WebSocketClient.Connect(peer, _log);
            _clientWebSocket.OnMessage = message => OnInvokeMessage(message);
            return _clientWebSocket;
        }

        public async Task SendMessage(string message)
        {
            await _clientWebSocket.SendAsync(message);
        }

        private void OnInvokeMessage(string message)
        {
            //Task.Factory.StartNew(async () => await ProcessMessage(message));  
        }

        #region Requests
        public async Task<Customer> GetCustomerRequest(string customerId)
        {
            byte[] buffer = new byte[20000];
            ArraySegment<byte> segment = new ArraySegment<byte>(buffer);
            GetCustomerRequest request = new GetCustomerRequest("get_customer", customerId);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _clientWebSocket.SendAsync(requestJson);
            bool gotCorrectResponse = false;
            string message = "";
            while (!gotCorrectResponse)
            {
                WebSocketReceiveResult result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await _clientWebSocket.DisconnectAsync();
                    throw new Exception("Disconnected. Close message");
                }
                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        await _clientWebSocket.DisconnectAsync();
                        throw new Exception("Disconnected. Buffer overloaded");
                    }
                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                    count += result.Count;
                }
                message = Encoding.UTF8.GetString(buffer, 0, count);
                WebMessageBase baseResponse = JsonConvert.DeserializeObject<WebMessageBase>(message);
                if (baseResponse.Tag == "get_customer")
                {
                    gotCorrectResponse = true;
                }
            }
            return ProcessGetCustomerResponse(message);
        }

        public async Task<IList<Merchandise>> GetMerchandisesRequest()
        {
            byte[] buffer = new byte[20000];
            ArraySegment<byte> segment = new ArraySegment<byte>(buffer);
            GetMerchandisesRequest request = new GetMerchandisesRequest("get_merchandises");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _clientWebSocket.SendAsync(requestJson);
            bool gotCorrectResponse = false;
            string message = "";
            while (!gotCorrectResponse)
            {
                WebSocketReceiveResult result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await _clientWebSocket.DisconnectAsync();
                    throw new Exception("Disconnected. Close message");
                }
                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        await _clientWebSocket.DisconnectAsync();
                        throw new Exception("Disconnected. Buffer overloaded");
                    }
                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                    count += result.Count;
                }
                message = Encoding.UTF8.GetString(buffer, 0, count);
                WebMessageBase baseResponse = JsonConvert.DeserializeObject<WebMessageBase>(message);
                if (baseResponse.Tag == "get_merchandises")
                {
                    gotCorrectResponse = true;
                }
            }
            return ProcessGetMerchandiseResponse(message);
        }

        public async Task<Order> GetOrderRequest(string orderId)
        {
            byte[] buffer = new byte[20000];
            ArraySegment<byte> segment = new ArraySegment<byte>(buffer);
            GetOrderRequest request = new GetOrderRequest("get_order", orderId);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _clientWebSocket.SendAsync(requestJson);
            bool gotCorrectResponse = false;
            string message = "";
            while (!gotCorrectResponse)
            {
                WebSocketReceiveResult result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await _clientWebSocket.DisconnectAsync();
                    throw new Exception("Disconnected. Close message");
                }
                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        await _clientWebSocket.DisconnectAsync();
                        throw new Exception("Disconnected. Buffer overloaded");
                    }
                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                    count += result.Count;
                }
                message = Encoding.UTF8.GetString(buffer, 0, count);
                WebMessageBase baseResponse = JsonConvert.DeserializeObject<WebMessageBase>(message);
                if (baseResponse.Tag == "get_order")
                {
                    gotCorrectResponse = true;
                }
            }
            return ProcessGetOrderResponse(message);
        }

        public async Task<string> MakeOrderRequest(Order order)
        {
            byte[] buffer = new byte[20000];
            ArraySegment<byte> segment = new ArraySegment<byte>(buffer);
            OrderModel orderModel = order.ToCommModel();
            OrderRequestResponse request = new OrderRequestResponse("make_order", orderModel);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _clientWebSocket.SendAsync(requestJson);
            bool gotCorrectResponse = false;
            string message = "";
            while (!gotCorrectResponse)
            {
                WebSocketReceiveResult result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await _clientWebSocket.DisconnectAsync();
                    throw new Exception("Disconnected. Close message");
                }
                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        await _clientWebSocket.DisconnectAsync();
                        throw new Exception("Disconnected. Buffer overloaded");
                    }
                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                    count += result.Count;
                }
                message = Encoding.UTF8.GetString(buffer, 0, count);
                WebMessageBase baseResponse = JsonConvert.DeserializeObject<WebMessageBase>(message);
                if (baseResponse.Tag == "make_order")
                {
                    gotCorrectResponse = true;
                }
            }
            return ProcessSaveOrderResponse(message);
        }

        public async Task<string> SubscribeDiscount()
        {
            byte[] buffer = new byte[20000];
            ArraySegment<byte> segment = new ArraySegment<byte>(buffer);
            WebMessageBase request = new WebMessageBase("subscription");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _clientWebSocket.SendAsync(requestJson);
            bool gotCorrectResponse = false;
            string message = "";
            while (!gotCorrectResponse)
            {
                WebSocketReceiveResult result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await _clientWebSocket.DisconnectAsync();
                    throw new Exception("Disconnected. Close message");
                }
                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        await _clientWebSocket.DisconnectAsync();
                        throw new Exception("Disconnected. Buffer overloaded");
                    }
                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                    count += result.Count;
                }
                message = Encoding.UTF8.GetString(buffer, 0, count);
                WebMessageBase baseResponse = JsonConvert.DeserializeObject<WebMessageBase>(message);
                if (baseResponse.Tag == "subscription")
                {
                    gotCorrectResponse = true;
                }
            }
            return ProcessSubscribeResponse(message);
        }

        public async Task<string> UnsubscribeDiscount()
        {
            byte[] buffer = new byte[20000];
            ArraySegment<byte> segment = new ArraySegment<byte>(buffer);
            WebMessageBase request = new WebMessageBase("unsubscription");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _clientWebSocket.SendAsync(requestJson);
            bool gotCorrectResponse = false;
            string message = "";
            while (!gotCorrectResponse)
            {
                WebSocketReceiveResult result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await _clientWebSocket.DisconnectAsync();
                    throw new Exception("Disconnected. Close message");
                }
                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        await _clientWebSocket.DisconnectAsync();
                        throw new Exception("Disconnected. Buffer overloaded");
                    }
                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                    count += result.Count;
                }
                message = Encoding.UTF8.GetString(buffer, 0, count);
                WebMessageBase baseResponse = JsonConvert.DeserializeObject<WebMessageBase>(message);
                if (baseResponse.Tag == "unsubscription")
                {
                    gotCorrectResponse = true;
                }
            }
            return ProcessUnsubscribeResponse(message);
        }
        #endregion

        #region MessagesProcessing
        //private async Task ProcessMessage(string message)
        //{
        //    try
        //    {
        //        WebMessageBase request = JsonConvert.DeserializeObject<WebMessageBase>(message);
        //        Debug.WriteLine("[{0}] Client received response: {1} , status: {2}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag, request.Status);
        //        string outp = String.Empty;

        //        if (request.Status == MessageStatus.FAIL)
        //        {
        //            _log(request.Message);
        //            return;
        //        }

        //        switch (request.Tag)
        //        {
        //            case "connection_established":
        //                {
        //                    await Task.Factory.StartNew(() => ProcessConnectionResponse());
        //                    break;
        //                }
        //            case "get_customer":
        //                {
        //                    await ProcessGetCustomerResponse(message);
        //                    break;
        //                }
        //            case "get_merchandises":
        //                {
        //                    await ProcessGetMerchandiseResponse(message);
        //                    break;
        //                }
        //            case "get_order":
        //                {
        //                    await  ProcessGetOrderResponse(message);
        //                    break;
        //                }
        //            case "make_order":
        //                {
        //                    await Task.Factory.StartNew(() => ProcessSaveOrderResponse(message));
        //                    break;
        //                }
        //            case "subscription":
        //                {
        //                    await Task.Factory.StartNew(() => ProcessSubscribeResponse());
        //                    break;
        //                }
        //            case "unsubscription":
        //                {
        //                    await Task.Factory.StartNew(() => ProcessUnsubscribeResponse());
        //                    break;
        //                }
        //            case "discount":
        //                {
        //                    await ProcessDiscountMessage(message);
        //                    break;
        //                }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        _log("Error: " + e.Message);
        //    }
        //}

        private string ProcessConnectionResponse(string message)
        {
            WebMessageBase response = JsonConvert.DeserializeObject<WebMessageBase>(message);
            if (response.Status == MessageStatus.SUCCESS)
                return "Connection established";
            else return "Could not establish connection";
        }

        private Customer ProcessGetCustomerResponse(string message)
        {
            GetCustomerResponse response = JsonConvert.DeserializeObject<GetCustomerResponse>(message);
            CustomerModel customerModel = response.Customer;
            _repository.RefreshCurrentCustomer(customerModel.FromCommModel());
            return _repository.GetCurrentCustomer();
        }

        private IList<Merchandise> ProcessGetMerchandiseResponse(string message)
        {
            GetMerchandisesResponse response = JsonConvert.DeserializeObject<GetMerchandisesResponse>(message);
            List<MerchandiseModel> merchandisesModels = response.Merchandises;
            List<Merchandise> products = merchandisesModels.FromCommModel();
            _repository.RefreshMerchandises(products);
            return _repository.GetMerchandises();
        }

        private Order ProcessGetOrderResponse(string message)
        {
            OrderRequestResponse response = JsonConvert.DeserializeObject<OrderRequestResponse>(message);
            Customer customer = response.Order.ClientInfo.FromCommModel();
            Order order = response.Order.FromCommModel();
            _repository.RefreshCurrentOrder(order);
            return _repository.GetCurrentOrder();
        }

        private string ProcessSaveOrderResponse(string message)
        {
            OrderRequestResponse response = JsonConvert.DeserializeObject<OrderRequestResponse>(message);
            string clientId = response.Order.ClientInfo.Id;
            string orderId = response.Order.Id;
            return "make_order:" + clientId + ":" + orderId;
        }

        private string ProcessSubscribeResponse(string message)
        {
            WebMessageBase response = JsonConvert.DeserializeObject<WebMessageBase>(message);
            if (response.Status == MessageStatus.SUCCESS)
                return "Subscribed " + response.Message;
            else return "Could not subscribe. " + response.Message;
        }

        private string ProcessUnsubscribeResponse(string message)
        {
            WebMessageBase response = JsonConvert.DeserializeObject<WebMessageBase>(message);
            return response.Message;
        }

        private Tuple<IList<Merchandise>, string> ProcessDiscountMessage(string message)
        {
            SubscriptionMessage response = JsonConvert.DeserializeObject<SubscriptionMessage>(message);
            double discount = response.discountData.Discount;
            List<Merchandise> responseProducts = response.discountData.Merchandises.FromCommModel();
            _repository.RefreshMerchandises(responseProducts);
            return new Tuple<IList<Merchandise>, string>(responseProducts, "discount: " + Math.Round(discount * 100.0, 2).ToString() + " %");
        }
        #endregion
    }
}
