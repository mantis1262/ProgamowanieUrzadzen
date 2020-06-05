using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Communication.Model;

namespace Communication.Responses
{
    [Serializable]
    public class SubscriptionMessage : WebMessageBase
    {

        [JsonProperty("discounEvent")]
        public DiscountData discountData;

        public SubscriptionMessage() : base()
        {
        }

        public SubscriptionMessage(string tag) : base(tag)
        {
        }

        public SubscriptionMessage(string tag, DiscountData discount) : base(tag)
        {
            discountData = discount;
        }

    }
}
