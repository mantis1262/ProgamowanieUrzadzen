using Communication.Requests;
using Communication.Model;
using Newtonsoft.Json;
using ServerLogic.Dto;
using ServerLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication.Responses;
using System.Net.WebSockets;
using ServerLogic.Observer;

namespace ServerPresentation
{
    public class MessageResolver
    {
        private Action<string> _log { get; }

        private OrderService _orderService { get; }

        public MessageResolver(OrderService orderService, Action<string> log)
        {
            _log = log;
            _orderService = orderService;
        }

        public async Task<string> Resolve(string message, WebSocketConnection ws)
        {
            WebMessageBase request = JsonConvert.DeserializeObject<WebMessageBase>(message);
            Console.WriteLine("[{0}] Resolving request: \"{1}\", status: {2}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag, request.Status);

            string output = String.Empty;
            switch (request.Tag)
            {
                case "get_customer":
                    {
                        GetCustomerRequest customerRequest = JsonConvert.DeserializeObject<GetCustomerRequest>(message);
                        output = await ProcessGetCustomerRequest(customerRequest);
                        break;
                    }
                case "get_merchandises":
                    {
                        GetMerchandisesRequest merchandiseRequest = JsonConvert.DeserializeObject<GetMerchandisesRequest>(message);
                        output = await ProcessGetMerchandisesRequest(merchandiseRequest);
                        break;
                    }
                case "get_order":
                    {
                        GetOrderRequest ordeRequest = JsonConvert.DeserializeObject<GetOrderRequest>(message);
                        output = await ProcessGetOrderRequest(ordeRequest);
                        break;
                    }
                case "make_order":
                    {
                        OrderRequestResponse orderRequest = JsonConvert.DeserializeObject<OrderRequestResponse>(message);
                        output = await ProcessMakeOrderRequest(orderRequest);
                        break;
                    }
                case "subscription":
                    {
                        WebMessageBase subRequest = JsonConvert.DeserializeObject<WebMessageBase>(message);
                        output = await ProcessSubscriptionRequest(subRequest, ws);
                        break;
                    }
                case "unsubscription":
                    {
                        WebMessageBase unSubRequest = JsonConvert.DeserializeObject<WebMessageBase>(message);
                        output = await ProcessUnsubscriptionRequest(unSubRequest, ws);
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
                    response.Status = MessageStatus.FAIL;
                    response.Message = "Customer with ID: " + request.Customer + " not found";
                    result = JsonConvert.SerializeObject(response, Formatting.Indented);
                    return result;
                }

                GetCustomerResponse customerResponse = new GetCustomerResponse("get_customer", customerDto.FromDto());
                result = JsonConvert.SerializeObject(customerResponse, Formatting.Indented);
                return result;
            }
            catch (Exception e)
            {
                WebMessageBase response = new WebMessageBase();
                response.Status = MessageStatus.FAIL;
                response.Message = "Could not get customer.";
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                _log("During processing get_customer requst an error occured: " + e.Message);
                return result;
            }
        }

        private async Task<string> ProcessGetMerchandisesRequest(GetMerchandisesRequest request)
        {
            try
            {
                List<MerchandiseDto> merchandiseDtos = (await _orderService.MerchandiseService.GetMerchandises()).ToList();
                GetMerchandisesResponse merchandisesResponse = new GetMerchandisesResponse("get_merchandises", merchandiseDtos.FromDto());
                string result = JsonConvert.SerializeObject(merchandisesResponse, Formatting.Indented);
                return result;
            }
            catch (Exception e)
            {
                WebMessageBase response = new WebMessageBase();
                response.Status = MessageStatus.FAIL;
                response.Message = "Get merchandise request error.";
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                _log("During processing get_merchandises request an error occured: " + e.Message);
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
                    response.Status = MessageStatus.FAIL;
                    response.Message = "Order with ID: " + request.Order + " not found";
                    result = JsonConvert.SerializeObject(response, Formatting.Indented);
                    return result;
                }

                OrderRequestResponse orderResponse = new OrderRequestResponse("get_order", orderDto.FromDto());
                result = JsonConvert.SerializeObject(orderResponse, Formatting.Indented);
                return result;
            }
            catch (Exception e)
            {
                WebMessageBase response = new WebMessageBase();
                response.Status = MessageStatus.FAIL;
                response.Message = "Could not get order !";
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                _log("During processing get_order request an error occured: " + e.Message);
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
                    clientID = await _orderService.CustomerService.SaveCustomer(request.Order.ClientInfo.ToDto());
                }

                CustomerDto clientDto = await _orderService.CustomerService.GetCustomer(clientID);
                string result;

                if (clientDto == null)
                {
                    WebMessageBase response = new WebMessageBase("make_order");
                    response.Status = MessageStatus.FAIL;
                    response.Message = "Client with ID: " + clientID + " not found";
                    result = JsonConvert.SerializeObject(response, Formatting.Indented);
                    return result;
                }

                string orderId = await _orderService.SaveOrder(request.Order.ToDto());
                OrderDto orderDto = await _orderService.GetOrder(orderId);

                if (orderDto == null)
                {
                    WebMessageBase response = new WebMessageBase("make_order");
                    response.Status = MessageStatus.FAIL;
                    response.Message = "Order with ID: " + request.Order.Id + " not found";
                    result = JsonConvert.SerializeObject(response, Formatting.Indented);
                    return result;
                }

                OrderRequestResponse orderResponse = new OrderRequestResponse("make_order", orderDto.FromDto());
                result = JsonConvert.SerializeObject(orderResponse, Formatting.Indented);
                return result;
            }
            catch (Exception e)
            {
                WebMessageBase response = new WebMessageBase();
                response.Status = MessageStatus.FAIL;
                response.Message = "Make order request error.";
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                _log("During processing save_order request an error occured: " + e.Message);
                return result;
            }
        }

        private async Task<string> ProcessSubscriptionRequest(WebMessageBase request, WebSocketConnection webSocketConnections)
        {
            try
            {
                Subscription subscription = new Subscription(webSocketConnections, _log);
                subscription.Unsubscriber = await _orderService.Subscribe(subscription);
                WebMessageBase response = new WebMessageBase("subscription");
                response.Status = MessageStatus.SUCCESS;
                response.Message = "Subscription request completed.";
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                return result;

            }
            catch (Exception e)
            {
                WebMessageBase response = new WebMessageBase();
                response.Status = MessageStatus.FAIL;
                response.Message = "Subscribe request error.";
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                _log("During processing subscription request an error occured: " + e.Message);
                return result;
            }
        }

        private async Task<string> ProcessUnsubscriptionRequest(WebMessageBase request, WebSocketConnection webSocketConnection)
        {
            try
            {
                IList<IObserver<DiscountEvent>> subs = await _orderService.GetSubscribers();
                foreach (Subscription subscription in subs)
                {
                    if (subscription.Websocket.Equals(webSocketConnection))
                    {
                        subscription.Unsubscriber.Dispose();
                        break;
                    }
                }

                WebMessageBase response = new WebMessageBase("unsubscription");
                response.Status = MessageStatus.SUCCESS;
                response.Message = "Unsubscribe request completed.";
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                return result;

            }
            catch (Exception e)
            {
                WebMessageBase response = new WebMessageBase();
                response.Status = MessageStatus.FAIL;
                response.Message = "Unsubscribe request error.";
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                _log("During processing subscription request an error occured: " + e.Message);
                return result;
            }
        }
    }
}
