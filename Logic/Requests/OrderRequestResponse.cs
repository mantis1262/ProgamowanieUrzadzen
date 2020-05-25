using Logic.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Requests
{
    [Serializable]
    public class OrderRequestResponse : WebMessageBase
    {
        [JsonProperty("order")]
        public OrderDto Order;
        [JsonProperty("client")]
        public CustomerDto Client;

        public OrderRequestResponse() : base()
        {
        }

        public OrderRequestResponse(string tag, OrderDto order) : base(tag)
        {
            Order = order;
        }

        public OrderRequestResponse(string tag, OrderDto order, CustomerDto client) : base(tag)
        {
            Order = order;
            Client = client;

        }
    }
}
