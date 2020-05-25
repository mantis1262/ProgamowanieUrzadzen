using Logic.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Subscription : IObserver<DiscountEvent>
    {
        private WebSocket _websocket;

        public Subscription(WebSocket websocket)
        {
            _websocket = websocket;
        }

        public void OnNext(DiscountEvent value)
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
