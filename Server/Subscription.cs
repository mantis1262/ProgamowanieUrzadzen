using Logic.Observer;
using Logic.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
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

        public async void OnNext(DiscountEvent value)
        {
            try
            {
                SubscriptionRequestResponse response = new SubscriptionRequestResponse("discount", value);
                response.Status = RequestStatus.SUCCESS;
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                ArraySegment<byte> outb = new ArraySegment<byte>(Encoding.UTF8.GetBytes(result));
                await _websocket.SendAsync(outb, WebSocketMessageType.Binary, true, CancellationToken.None);
            } catch (Exception e)
            {
                Console.WriteLine("Discount request error.");
            }
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
