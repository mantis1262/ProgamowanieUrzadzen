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
        private ClientWebSocketConnection _clientDiscountWebSocket;
        private IRepository _repository;
        private Action<string> _log;
        private ISubject<string> _messageChain;
        private CancellationToken _timeOut = CancellationToken.None;

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
            _clientDiscountWebSocket = (ClientWebSocketConnection)await WebSocketClient.Connect(peer, _log, true);
            _clientDiscountWebSocket.OnMessage = message => OnInvokeMessage(message);
        }

        public void Disconnect()
        {
            _clientWebSocket.Disconnect();
            if (_clientDiscountWebSocket != null)
            {
                if (_clientDiscountWebSocket.ClientWebSocket.State == WebSocketState.Open)
                    _clientDiscountWebSocket.Disconnect();
            }         
        }

        public async Task SendMessage(string message)
        {
            await _clientWebSocket.SendAsync(message);
        }

        private void OnInvokeMessage(string message)
        {
            ProcessMessage(message);
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
                WebSocketReceiveResult result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, _timeOut).Result;
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    _clientWebSocket.Disconnect();
                    throw new Exception("Disconnected. Close message");
                }
                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        _clientWebSocket.Disconnect();
                        throw new Exception("Disconnected. Buffer overloaded");
                    }
                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, _timeOut).Result;
                    count += result.Count;
                }
                message = Encoding.UTF8.GetString(buffer, 0, count);
                WebMessageBase baseResponse = JsonConvert.DeserializeObject<WebMessageBase>(message);
                if (baseResponse.Tag == "get_customer")
                {
                    gotCorrectResponse = true;
                    if (baseResponse.Status != MessageStatus.SUCCESS)
                    {
                        throw new Exception(baseResponse.Message);
                    }
                }
            }
            GetCustomerResponse response = JsonConvert.DeserializeObject<GetCustomerResponse>(message);
            return response.Customer.FromCommModel();
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
                WebSocketReceiveResult result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, _timeOut).Result;
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    _clientWebSocket.Disconnect();
                    throw new Exception("Disconnected. Close message");
                }
                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        _clientWebSocket.Disconnect();
                        throw new Exception("Disconnected. Buffer overloaded");
                    }
                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, _timeOut).Result;
                    count += result.Count;
                }
                message = Encoding.UTF8.GetString(buffer, 0, count);
                WebMessageBase baseResponse = JsonConvert.DeserializeObject<WebMessageBase>(message);
                if (baseResponse.Tag == "get_merchandises")
                {
                    gotCorrectResponse = true;
                    if (baseResponse.Status != MessageStatus.SUCCESS)
                    {
                        throw new Exception(baseResponse.Message);
                    }
                }
            }
            GetMerchandisesResponse response = JsonConvert.DeserializeObject<GetMerchandisesResponse>(message);
            return response.Merchandises.FromCommModel();
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
                WebSocketReceiveResult result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, _timeOut).Result;
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    _clientWebSocket.Disconnect();
                    throw new Exception("Disconnected. Close message");
                }
                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        _clientWebSocket.Disconnect();
                        throw new Exception("Disconnected. Buffer overloaded");
                    }
                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, _timeOut).Result;
                    count += result.Count;
                }
                message = Encoding.UTF8.GetString(buffer, 0, count);
                WebMessageBase baseResponse = JsonConvert.DeserializeObject<WebMessageBase>(message);
                if (baseResponse.Tag == "get_order")
                {
                    gotCorrectResponse = true;
                    if (baseResponse.Status != MessageStatus.SUCCESS)
                    {
                        throw new Exception(baseResponse.Message);
                    }
                }
            }
            OrderRequestResponse response = JsonConvert.DeserializeObject<OrderRequestResponse>(message);
            return response.Order.FromCommModel();
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
                WebSocketReceiveResult result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, _timeOut).Result;
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    _clientWebSocket.Disconnect();
                    throw new Exception("Disconnected. Close message");
                }
                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        _clientWebSocket.Disconnect();
                        throw new Exception("Disconnected. Buffer overloaded");
                    }
                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = _clientWebSocket.ClientWebSocket.ReceiveAsync(segment, _timeOut).Result;
                    count += result.Count;
                }
                message = Encoding.UTF8.GetString(buffer, 0, count);
                WebMessageBase baseResponse = JsonConvert.DeserializeObject<WebMessageBase>(message);
                if (baseResponse.Tag == "make_order")
                {
                    gotCorrectResponse = true;
                    if (baseResponse.Status != MessageStatus.SUCCESS)
                    {
                        throw new Exception(baseResponse.Message);
                    }
                }
            }
            OrderRequestResponse response = JsonConvert.DeserializeObject<OrderRequestResponse>(message);
            string clientId = response.Order.ClientInfo.Id;
            string orderId = response.Order.Id;
            return "make_order:" + clientId + ":" + orderId;
        }

        public async Task<string> SubscribeDiscount()
        {
            byte[] buffer = new byte[20000];
            ArraySegment<byte> segment = new ArraySegment<byte>(buffer);
            WebMessageBase request = new WebMessageBase("subscription");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented); 
            await _clientDiscountWebSocket.SendAsync(requestJson);
            bool gotCorrectResponse = false;
            string mesg = "";
            while (!gotCorrectResponse)
            {
                WebSocketReceiveResult result = _clientDiscountWebSocket.ClientWebSocket.ReceiveAsync(segment, _timeOut).Result;
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    _clientDiscountWebSocket.Disconnect();
                    throw new Exception("Disconnected. Close message");
                }
                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        _clientDiscountWebSocket.Disconnect();
                        throw new Exception("Disconnected. Buffer overloaded");
                    }
                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = _clientDiscountWebSocket.ClientWebSocket.ReceiveAsync(segment, _timeOut).Result;
                    count += result.Count;
                }
                mesg = Encoding.UTF8.GetString(buffer, 0, count);
                WebMessageBase baseResponse = JsonConvert.DeserializeObject<WebMessageBase>(mesg);
                if (baseResponse.Tag == "subscription")
                {
                    gotCorrectResponse = true;
                    if (baseResponse.Status != MessageStatus.SUCCESS)
                    {
                        throw new Exception(baseResponse.Message);
                    }
                }
            }
            _clientDiscountWebSocket.ActiveMessageLoop = true;
            WebMessageBase response = JsonConvert.DeserializeObject<WebMessageBase>(mesg);
            if (response.Status == MessageStatus.SUCCESS)
                return response.Message;
            else return "Could not subscribe. " + response.Message;
        }

        public async Task<string> UnsubscribeDiscount()
        {
            WebMessageBase request = new WebMessageBase("unsubscription");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            _clientDiscountWebSocket.ActiveMessageLoop = false;
            await _clientDiscountWebSocket.SendAsync(requestJson);
            return "unsubscription";
        }
        #endregion

        #region MessagesProcessing
        private void ProcessMessage(string message)
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

                if (request.Tag == "unsubscription")
                {
                    _messageChain.OnNext("unsubscription");
                }

                if (request.Tag == "discount")
                {
                    _messageChain.OnNext(ProcessDiscountMessage(message));
                }
            }
            catch (Exception e)
            {
                _log("Error: " + e.Message);
            }
        }

        private string ProcessDiscountMessage(string message)
        {
            SubscriptionMessage response = JsonConvert.DeserializeObject<SubscriptionMessage>(message);
            double discount = response.discountData.Discount;
            List<Merchandise> responseProducts = response.discountData.Merchandises.FromCommModel();
            _repository.RefreshMerchandises(responseProducts);
            return "discount: " + Math.Round(discount * 100.0, 2).ToString() + " %";
        }
        #endregion
    }
}
