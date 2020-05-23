using Logic.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Requests
{
    [Serializable]
    public class GetMerchandisesResponse : WebMessageBase
    {
        [JsonProperty("merchandises")]
        public List<MerchandiseDto> Merchandises;

        public GetMerchandisesResponse() : base()
        {
        }

        public GetMerchandisesResponse(string tag, List<MerchandiseDto> merchandises) : base(tag)
        {
            Merchandises = merchandises;
        }
    }
}
