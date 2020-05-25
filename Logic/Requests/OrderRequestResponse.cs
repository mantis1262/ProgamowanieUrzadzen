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

        public OrderRequestResponse() : base()
        {
        }

        public OrderRequestResponse(string tag, OrderDto order) : base(tag)
        {
            Order = order;
        }
    }
}
