using Logic.Dto;
using Logic.Requests;
using Logic.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class WebSocketServer
    {
        private OrderService _orderService;

        public async void Start(string httpListenerPrefix)
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add(httpListenerPrefix);
            server.Start();
            Console.WriteLine("[{0}] Server is listening on " + httpListenerPrefix + " ...", DateTime.Now.ToString("HH:mm:ss.fff"));

            _orderService = new OrderService(true);

            while (true)
            {
                HttpListenerContext httpListenerContext = await server.GetContextAsync();
                if (!httpListenerContext.Request.IsWebSocketRequest)
                {
                    httpListenerContext.Response.StatusCode = 400;
                    httpListenerContext.Response.Close();
                }
                ProcessRequest(httpListenerContext);
            }
        }

        private async void ProcessRequest(HttpListenerContext httpListenerContext)
        {
            WebSocketContext webSocketContext = null;
            string ipAddress = string.Empty;
            try
            {
                webSocketContext = await httpListenerContext.AcceptWebSocketAsync(null);
                ipAddress = httpListenerContext.Request.RemoteEndPoint.Address.ToString();
                Console.WriteLine("[{0}] Connected with: {1}", DateTime.Now.ToString("HH:mm:ss.fff"), ipAddress);
            }
            catch (Exception e)
            {
                httpListenerContext.Response.StatusCode = 500;
                httpListenerContext.Response.Close();
                Console.WriteLine("Wyjątek {0}", e);
                return;
            }

            WebSocket webSocket = webSocketContext.WebSocket;

            try
            {
                int size = 8192;
                byte[] receiveBuffer = new byte[size];
                while (webSocket.State == WebSocketState.Open)
                {
                    Array.Clear(receiveBuffer, 0, receiveBuffer.Length);
                    WebSocketReceiveResult receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);

                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed.", CancellationToken.None);
                    }
                    else
                    {
                        string response = await ProcessData(Encoding.UTF8.GetString(receiveBuffer).TrimEnd('\0'), ipAddress, webSocket);
                        ArraySegment<byte> outb = new ArraySegment<byte>(Encoding.UTF8.GetBytes(response));
                        await webSocket.SendAsync(outb, WebSocketMessageType.Binary, receiveResult.EndOfMessage, CancellationToken.None);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
            finally
            {
                if (webSocket != null)
                {
                    webSocket.Dispose();
                }
            }
        }

        private async Task<string> ProcessData(string rawData, string ipAddress, WebSocket webSocket)
        {
            WebMessageBase request = JsonConvert.DeserializeObject<WebMessageBase>(rawData);
            Console.WriteLine("[{0}] Serwer otrzymał zapytanie: \"{1}\" od {2}, status: {3}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag, ipAddress, request.Status);

            string output = String.Empty;
            switch (request.Tag)
            {
                case "get_customer":
                    {
                        GetCustomerRequest customerRequest = JsonConvert.DeserializeObject<GetCustomerRequest>(rawData);
                        output = await ProcessGetCustomerRequest(customerRequest);
                        break;
                    }
                case "get_merchandises":
                    {
                        GetMerchandisesRequest merchandiseRequest = JsonConvert.DeserializeObject<GetMerchandisesRequest>(rawData);
                        output = await ProcessGetMerchandisesRequest(merchandiseRequest);
                        break;
                    }
                case "get_order":
                    {
                        GetOrderRequest ordeRequest = JsonConvert.DeserializeObject<GetOrderRequest>(rawData);
                        output = await ProcessGetOrderRequest(ordeRequest);
                        break;
                    }
                case "make_order":
                    {
                        OrderRequestResponse orderRequest = JsonConvert.DeserializeObject<OrderRequestResponse>(rawData);
                        output = await ProcessMakeOrderRequest(orderRequest);
                        break;
                    }
                case "subscription":
                    {
                        WebMessageBase subRequest = JsonConvert.DeserializeObject<WebMessageBase>(rawData);
                        output = await ProcessSubscriptionRequest(subRequest, webSocket);
                        break;
                    }
            }

            return output;
        }

        private async Task<string> ProcessGetCustomerRequest(GetCustomerRequest request)
        {
            try
            {
                CustomerDto customerDto = await _orderService.CustomerService.GetCustomer(request.Customer);
                string result;

                if (customerDto == null)
                {
                    WebMessageBase response = new WebMessageBase("get_customer");
                    response.Status = RequestStatus.FAIL;
                    response.Message = "Customer with ID: " + request.Customer + " not found";
                    result = JsonConvert.SerializeObject(response, Formatting.Indented);
                    return result;
                }

                GetCustomerResponse customerResponse = new GetCustomerResponse("get_customer", customerDto);
                result = JsonConvert.SerializeObject(customerResponse, Formatting.Indented);
                return result;
            } catch (Exception e)
            {
                WebMessageBase response = new WebMessageBase();
                response.Status = RequestStatus.FAIL;
                response.Message = "Get customer request error.";
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                return result;
            }
        }

        private async Task<string> ProcessSubscriptionRequest(WebMessageBase request, WebSocket webSocket )
        {
            try
            {
                Subscription subscription = new Subscription(webSocket);
                _orderService.CyclicDiscountService.Provider.Subscribe(subscription);
                WebMessageBase response = new WebMessageBase();
                response.Status = RequestStatus.SUCCESS;
                response.Message = "Subsctipte request completed.";
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                return result;

            } catch (Exception e)
            {
                WebMessageBase response = new WebMessageBase();
                response.Status = RequestStatus.FAIL;
                response.Message = "Subsctipte request error.";
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                return result;
            }
        }
        private async Task<string> ProcessGetMerchandisesRequest(GetMerchandisesRequest request)
        {
            try 
            { 
                List<MerchandiseDto> merchandiseDtos = (await _orderService.MerchandiseService.GetMerchandises()).ToList();
                GetMerchandisesResponse merchandisesResponse = new GetMerchandisesResponse("get_merchandises", merchandiseDtos);
                string result = JsonConvert.SerializeObject(merchandisesResponse, Formatting.Indented);
                return result;
            } catch (Exception e)
            {
                WebMessageBase response = new WebMessageBase();
                response.Status = RequestStatus.FAIL;
                response.Message = "Get merchandise request error.";
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                return result;
            }
}

        private async Task<string> ProcessGetOrderRequest(GetOrderRequest request)
        {
            try 
            { 
                OrderDto orderDto = await _orderService.GetOrder(request.Order);
                string result;

                if (orderDto == null)
                {
                    WebMessageBase response = new WebMessageBase("get_order");
                    response.Status = RequestStatus.FAIL;
                    response.Message = "Order with ID: " + request.Order + " not found";
                    result = JsonConvert.SerializeObject(response, Formatting.Indented);
                    return result;
                }

                OrderRequestResponse orderResponse = new OrderRequestResponse("get_order", orderDto);
                result = JsonConvert.SerializeObject(orderResponse, Formatting.Indented);
                return result;
            }
            catch (Exception e)
            {
                WebMessageBase response = new WebMessageBase();
                response.Status = RequestStatus.FAIL;
                response.Message = "Get order request error.";
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                return result;
            }
        }

        private async Task<string> ProcessMakeOrderRequest(OrderRequestResponse request)
        {
            try
            { 
                string clientID = request.Order.ClientInfo.Id;
                if (string.IsNullOrEmpty(clientID) || string.IsNullOrWhiteSpace(clientID))
                {
                    clientID = await _orderService.CustomerService.SaveCustomer(request.Order.ClientInfo);
                }

                CustomerDto clientDto = await _orderService.CustomerService.GetCustomer(clientID);
                string result;

                if (clientDto == null)
                {
                    WebMessageBase response = new WebMessageBase("get_customer");
                    response.Status = RequestStatus.FAIL;
                    response.Message = "Client with ID: " + clientID + " not found";
                    result = JsonConvert.SerializeObject(response, Formatting.Indented);
                    return result;
                }

                string orderId = await _orderService.SaveOrder(request.Order);
                OrderDto orderDto = await _orderService.GetOrder(orderId);  

                if (orderDto == null)
                {
                    WebMessageBase response = new WebMessageBase("get_order");
                    response.Status = RequestStatus.FAIL;
                    response.Message = "Order with ID: " + request.Order.Id + " not found";
                    result = JsonConvert.SerializeObject(response, Formatting.Indented);
                    return result;
                }

                OrderRequestResponse orderResponse = new OrderRequestResponse("save_order", orderDto);
                result = JsonConvert.SerializeObject(orderResponse, Formatting.Indented);
                return result;
            }
            catch (Exception e)
            {
                WebMessageBase response = new WebMessageBase();
                response.Status = RequestStatus.FAIL;
                response.Message = "Make order request error.";
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                return result;
            }
        }
    }
}
