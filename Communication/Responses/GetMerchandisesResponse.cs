using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Communication;
using Communication.Model;

namespace Communication.Responses
{
    [Serializable]
    public class GetMerchandisesResponse : WebMessageBase
    {
        [JsonProperty("merchandises")]
        public List<MerchandiseModel> Merchandises;

        public GetMerchandisesResponse() : base()
        {
        }

        public GetMerchandisesResponse(string tag, List<MerchandiseModel> merchandises) : base(tag)
        {
            Merchandises = merchandises;
        }
    }
}
