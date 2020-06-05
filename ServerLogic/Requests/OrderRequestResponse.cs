using ServerLogic.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogic.Requests
{
    [Serializable]
    public class OrderRequestResponse : WebMessageBase
    {
        [JsonProperty("order")]
        public OrderDto Order;

        public OrderRequestResponse() : base()
        {
        }

        public OrderRequestResponse(string tag, OrderDto order) : base(tag)
        {
            Order = order;
        }
    }
}
