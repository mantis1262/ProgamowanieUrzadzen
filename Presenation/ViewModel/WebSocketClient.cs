using Logic.Dto;
using Logic.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Presenation.ViewModel
{
    public class WebSocketClient
    {
        private UTF8Encoding encoding = new UTF8Encoding();
        private ClientWebSocket webSocket = null;
        public ISubject<string> OnMessage = new Subject<string>();

        public async Task Connect(string uri)
        {
            Thread.Sleep(1000);

            try
            {
                webSocket = new ClientWebSocket();
                await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
                await Task.WhenAll(Receive());
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: {0}", e);
            }
            finally
            {
                if (webSocket != null)
                {
                    webSocket.Dispose();
                }

                Debug.WriteLine("");
                Debug.WriteLine("Websocket has been close.");
            }
        }

        private async Task Send(string stringToSend)
        {
            if (webSocket.State == WebSocketState.Open)
            {
                byte[] buffer = encoding.GetBytes(stringToSend);
                await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Binary, false, CancellationToken.None);
            }
        }

        public async Task GetCustomerRequest(string customerId)
        {
            GetCustomerRequest request = new GetCustomerRequest("get_customer", customerId);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await Send(requestJson);
            Debug.WriteLine("[{0}] Client has sent request: {1}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag);
        }

        public async Task GetMerchandisesRequest()
        {
            GetMerchandisesRequest request = new GetMerchandisesRequest("get_merchandises");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await Send(requestJson);
            Debug.WriteLine("[{0}] Client has sent request: {1}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag);
        }

        public async Task GetOrderRequest(string orderId)
        {
            GetOrderRequest request = new GetOrderRequest("get_order", orderId);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await Send(requestJson);
            Debug.WriteLine("[{0}] Client has sent request: {1}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag);
        }

        public async Task MakeOrderRequest(OrderDto order)
        {
            OrderRequestResponse request = new OrderRequestResponse("make_order", order);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await Send(requestJson);
            Debug.WriteLine("[{0}] Client has sent request: {1}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag);
        }

        public async Task SubscribeDiscount()
        {
            WebMessageBase request = new WebMessageBase("subscription");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await Send(requestJson);
            Debug.WriteLine("[{0}] Client has sent request: {1}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag);
        }

        private async Task Receive()
        {
            int size = 8192;
            byte[] buffer = new byte[size];
            while (webSocket.State == WebSocketState.Open)
            {
                Array.Clear(buffer, 0, buffer.Length);
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
                else
                {
                    string message = Encoding.UTF8.GetString(buffer).TrimEnd('\0');
                    OnMessage.OnNext(message);
                }
            }
        }
    }
}
