using ServerLogic.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogic.Requests
{
    [Serializable]
    public class GetCustomerResponse : WebMessageBase
    {
        [JsonProperty("customer")]
        public CustomerDto Customer;

        public GetCustomerResponse() : base()
        {
        }

        public GetCustomerResponse(string tag, CustomerDto customer) : base(tag)
        {
            Customer = customer;
        }
    }
}
