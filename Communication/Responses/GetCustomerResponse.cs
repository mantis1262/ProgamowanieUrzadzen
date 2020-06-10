using Communication.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Communication.Responses
{
    [Serializable]
    public class GetCustomerResponse : WebMessageBase
    {
        [JsonProperty("customer")]
        public CustomerModel Customer;

        public GetCustomerResponse() : base()
        {
        }

        public GetCustomerResponse(string tag, CustomerModel customer) : base(tag)
        {
            Customer = customer;
        }
    }
}
