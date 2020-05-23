using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Requests
{
    [Serializable]
    public class WebMessageBase
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("status")]
        public RequestStatus Status = RequestStatus.SUCCESS;

        [JsonProperty("message")]
        public string Message = "";

        public WebMessageBase()
        {
        }

        public WebMessageBase(string tag)
        {
            Tag = tag;
        }

    }
}
