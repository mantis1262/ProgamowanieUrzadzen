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
using System.Windows;
using System.Windows.Forms;

namespace Presenation.ViewModel
{
    public class WebSocketClient: IDisposable
    {
        private UTF8Encoding _encoding = new UTF8Encoding();
        private ClientWebSocket _webSocket = null;
        public ISubject<string> OnMessage = new Subject<string>();

        public async void Connect(string uri)
        {
            Thread.Sleep(1000);

            try
            {
                _webSocket = new ClientWebSocket();
                await _webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
                await Task.WhenAll(Receive());
            }
            catch (Exception e)
            {
                ShowErrorPopupWindow("Error: " + e.Message);
            }
            finally
            {
                if (_webSocket != null)
                {
                    _webSocket.Dispose();
                }

                ShowInfoPopupWindow("Websocket has been closed.");
            }
        }

        #region Requests
        private async Task Send(string stringToSend)
        {
            if (_webSocket.State == WebSocketState.Open)
            {
                byte[] buffer = _encoding.GetBytes(stringToSend);
                await _webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Binary, false, CancellationToken.None);
            }
        }

        public async void GetCustomerRequest(string customerId)
        {
            GetCustomerRequest request = new GetCustomerRequest("get_customer", customerId);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await Send(requestJson);
            Debug.WriteLine("[{0}] Client has sent request: {1}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag);
        }

        public async void GetMerchandisesRequest()
        {
            GetMerchandisesRequest request = new GetMerchandisesRequest("get_merchandises");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await Send(requestJson);
            Debug.WriteLine("[{0}] Client has sent request: {1}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag);
        }

        public async void GetOrderRequest(string orderId)
        {
            GetOrderRequest request = new GetOrderRequest("get_order", orderId);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await Send(requestJson);
            Debug.WriteLine("[{0}] Client has sent request: {1}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag);
        }

        public async void MakeOrderRequest(OrderDto order)
        {
            OrderRequestResponse request = new OrderRequestResponse("make_order", order);
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await Send(requestJson);
            Debug.WriteLine("[{0}] Client has sent request: {1}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag);
        }

        public async void SubscribeDiscount()
        {
            WebMessageBase request = new WebMessageBase("subscription");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await Send(requestJson);
            Debug.WriteLine("[{0}] Client has sent request: {1}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag);
        }

        public async void UnsubscribeDiscount()
        {
            WebMessageBase request = new WebMessageBase("unsubscription");
            string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            await Send(requestJson);
            Debug.WriteLine("[{0}] Client has sent request: {1}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag);
        }
        #endregion

        private async Task Receive()
        {
            int size = 8192;
            byte[] buffer = new byte[size];
            while (_webSocket.State == WebSocketState.Open)
            {
                Array.Clear(buffer, 0, buffer.Length);
                WebSocketReceiveResult result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                    ShowInfoPopupWindow("Websocket has been closed.");
                }
                else
                {
                    string message = Encoding.UTF8.GetString(buffer).TrimEnd('\0');
                    OnMessage.OnNext(message);
                }
            }
        }

        #region MessageLog
        internal Func<string, string, MessageBoxButton, MessageBoxImage, MessageBoxResult> MessageBoxShowDelegate { get; set; } = System.Windows.MessageBox.Show;

        private void ShowErrorPopupWindow(string mesg)
        {
            MessageBoxShowDelegate(mesg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ShowInfoPopupWindow(string mesg)
        {
            MessageBoxShowDelegate(mesg, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion MessageLog

        #region Dispose
        public void Dispose()
        {
            if (_webSocket != null)
            {
                Dispose(true);
            }
        }

        public async void Dispose(bool disposing)
        {
            await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
        }
        #endregion
    }
}
