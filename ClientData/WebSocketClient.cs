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

namespace ClientData
{
    public class WebSocketClient : IDisposable
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
                Debug.WriteLine("Error: " + e.Message);
            }
            finally
            {
                if (_webSocket != null)
                {
                    _webSocket.Dispose();
                }

                Debug.WriteLine("Websocket has been closed.");
            }
        }
        public async Task Send(string stringToSend)
        {
            if (_webSocket.State == WebSocketState.Open)
            {
                byte[] buffer = _encoding.GetBytes(stringToSend);
                await _webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Binary, false, CancellationToken.None);
            }
        }



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
                    Debug.WriteLine("Websocket has been closed.");
                }
                else
                {
                    string message = Encoding.UTF8.GetString(buffer).TrimEnd('\0');
                    OnMessage.OnNext(message);
                }
            }
        }

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
