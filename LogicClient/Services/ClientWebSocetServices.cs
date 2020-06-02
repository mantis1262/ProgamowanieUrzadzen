using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic.Dto;
using Logic.Requests;
using Newtonsoft.Json;

namespace Logic.Services
{
   public class ClientWebSocetServices
    {

        private WebSocketClient _webSocketClient;
        public WebSocketClient WebSocketClients { get => _webSocketClient; set => _webSocketClient = value; }


        public ClientWebSocetServices()
        {
            _webSocketClient = new WebSocketClient();
        }

        public ClientWebSocetServices(WebSocketClient webSocketClient)
        {
            _webSocketClient = webSocketClient;
        }




        #region Requests

        public async void GetCustomerRequest(string customerId)
        {
            GetCustomerRequest request = new GetCustomerRequest("get_customer", customerId);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);

            await _webSocketClient.Send(requestJson);
        }

        public async void GetMerchandisesRequest()
        {
            GetMerchandisesRequest request = new GetMerchandisesRequest("get_merchandises");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _webSocketClient.Send(requestJson);
        }

        public async void GetOrderRequest(string orderId)
        {
            GetOrderRequest request = new GetOrderRequest("get_order", orderId);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _webSocketClient.Send(requestJson);
        }

        public async void MakeOrderRequest(OrderDto order)
        {
            OrderRequestResponse request = new OrderRequestResponse("make_order", order);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _webSocketClient.Send(requestJson);

        }

        public async void SubscribeDiscount()
        {
            WebMessageBase request = new WebMessageBase("subscription");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _webSocketClient.Send(requestJson);

        }

        public async void UnsubscribeDiscount()
        {
            WebMessageBase request = new WebMessageBase("unsubscription");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await _webSocketClient.Send(requestJson);
        }

        #endregion

    }
}
