using ServerLogic.Observer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Communication.Model;
using Communication.Responses;

namespace ServerPresentation
{
    public class Subscription : IObserver<DiscountEvent>
    {
        private WebSocketConnection _websocketConnection;
        private IDisposable _unsubscriber;
        private Action<string> _log;

        public IDisposable Unsubscriber { get => _unsubscriber; set => _unsubscriber = value; }
        public WebSocketConnection Websocket { get => _websocketConnection; set => _websocketConnection = value; }

        public Subscription(WebSocketConnection websocketConnection, Action<string> log)
        {
            _websocketConnection = websocketConnection;
            _log = log;
        }

        public async void OnNext(DiscountEvent value)
        {
            try
            {
                DiscountData discountData = new DiscountData(value.Discount, value.Merchandises.FromDto());
                SubscriptionMessage response = new SubscriptionMessage("discount", discountData);
                response.Status = MessageStatus.SUCCESS;
                string result = JsonConvert.SerializeObject(response, Formatting.Indented);
                await _websocketConnection.WebSocket.SendAsync(result.GetArraySegment(), WebSocketMessageType.Binary, true, CancellationToken.None);
            } catch (Exception e)
            {
                _log("Discount OnNext operation error: " + e.Message);
            }
        }

        public void OnError(Exception error)
        {
            _log("Discount OnError operation error.");
        }

        public void OnCompleted()
        {
            _unsubscriber.Dispose();
        }
    }
}
