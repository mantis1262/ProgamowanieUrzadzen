using ClientLogic.Observer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientLogic.Requests
{
    [Serializable]
    public class SubscriptionRequestResponse : WebMessageBase
    {

        [JsonProperty("discounEvent")]
        public DiscountEvent discountEvent;

        public SubscriptionRequestResponse() : base()
        {
        }

        public SubscriptionRequestResponse(string tag) : base(tag)
        {
        }

        public SubscriptionRequestResponse(string tag, DiscountEvent discount) : base(tag)
        {
            discountEvent = discount;
        }

    }
}
