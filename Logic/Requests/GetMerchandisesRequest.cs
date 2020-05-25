using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Requests
{
    public class GetMerchandisesRequest : WebMessageBase
    {
        public GetMerchandisesRequest() : base()
        {
        }

        public GetMerchandisesRequest(string tag) : base(tag)
        {
            
        }
    }
}
