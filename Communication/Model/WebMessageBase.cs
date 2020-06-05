using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Communication.Model
{
    [Serializable]
    public class WebMessageBase
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("status")]
        public MessageStatus Status = MessageStatus.SUCCESS;

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
