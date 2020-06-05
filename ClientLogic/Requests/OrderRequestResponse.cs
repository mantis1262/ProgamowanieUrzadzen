using ClientLogic.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientLogic.Requests
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
