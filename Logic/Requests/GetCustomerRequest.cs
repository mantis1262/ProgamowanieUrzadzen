﻿using Logic.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Requests
{
    [Serializable]
    public class GetCustomerRequest : WebMessageBase
    {
        [JsonProperty("customer")]
        public string Customer;

        public GetCustomerRequest() : base()
        {
        }

        public GetCustomerRequest(string tag, string customer) : base(tag)
        {
            Customer = customer;
        }
    }
}
