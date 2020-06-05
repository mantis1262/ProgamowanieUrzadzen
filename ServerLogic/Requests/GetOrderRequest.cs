using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogic.Requests
{
    [Serializable]
    public class GetOrderRequest : WebMessageBase
    {
        [JsonProperty("order")]
        public string Order;

        public GetOrderRequest() : base()
        {
        }

        public GetOrderRequest(string tag, string order) : base(tag)
        {
            Order = order;
        }
    }
}
