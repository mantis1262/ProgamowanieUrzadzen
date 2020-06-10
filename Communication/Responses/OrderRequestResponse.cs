using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Communication;
using Communication.Model;

namespace Communication.Responses
{
    [Serializable]
    public class OrderRequestResponse : WebMessageBase
    {
        [JsonProperty("order")]
        public OrderModel Order;

        public OrderRequestResponse() : base()
        {
        }

        public OrderRequestResponse(string tag, OrderModel order) : base(tag)
        {
            Order = order;
        }
    }
}
