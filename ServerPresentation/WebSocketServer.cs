using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerPresentation
{
    public static class WebSocketServer
    {
        public static async Task Server(int p2p_port, Action<WebSocketConnection> onConnection, Action<string> logger)
        {
            Uri _uri = new Uri($@"http://localhost:{p2p_port}/");
            await ServerLoop(_uri, onConnection, logger);
        }

        #region private
        private static async Task ServerLoop(Uri _uri, Action<WebSocketConnection> onConnection, Action<string> logger)
        {
            HttpListener _server = new HttpListener();
            _server.Prefixes.Add(_uri.ToString());
            _server.Start();
            while (true)
            {
                HttpListenerContext _hc = await _server.GetContextAsync();
                if (!_hc.Request.IsWebSocketRequest)
                {
                    _hc.Response.StatusCode = 400;
                    _hc.Response.Close();
                }
                HttpListenerWebSocketContext _context = await _hc.AcceptWebSocketAsync(null);
                WebSocketConnection ws = new ServerWebSocketConnection(_context.WebSocket, _hc.Request.RemoteEndPoint, logger);
                onConnection?.Invoke(ws);
            }
        }

        private class ServerWebSocketConnection : WebSocketConnection
        {
            private IPEndPoint _remoteEndPoint;
            private Action<string> _log;

            public ServerWebSocketConnection(WebSocket webSocket, IPEndPoint remoteEndPoint, Action<string> logger)
            {
                _log = logger;
                WebSocket = webSocket;
                _remoteEndPoint = remoteEndPoint;
                Task.Factory.StartNew(() => ServerMessageLoop(webSocket));
            }

            #region WebSocketConnection

            protected override Task SendTask(string message)
            {
                return WebSocket.SendAsync(message.GetArraySegment(), WebSocketMessageType.Text, true, CancellationToken.None);
            }

            public override Task DisconnectAsync()
            {
                return WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Shutdown procedure started", CancellationToken.None);
            }

            #endregion WebSocketConnection

            #region Object

            public override string ToString()
            {
                return _remoteEndPoint.ToString();
            }

            #endregion Object

            private void ServerMessageLoop(WebSocket ws)
            {
                byte[] buffer = new byte[20000];
                while (true)
                {
                    try
                    {
                        ArraySegment<byte> _segments = new ArraySegment<byte>(buffer);
                        WebSocketReceiveResult _receiveResult = ws.ReceiveAsync(_segments, CancellationToken.None).Result;
                        if (_receiveResult.MessageType == WebSocketMessageType.Close)
                        {
                            OnClose?.Invoke();
                            ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "I am closing", CancellationToken.None).Wait();
                            return;
                        }
                        int count = _receiveResult.Count;
                        while (!_receiveResult.EndOfMessage)
                        {
                            if (count >= buffer.Length)
                            {
                                OnClose?.Invoke();
                                ws.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None).Wait();
                                return;
                            }
                            _segments = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                            _receiveResult = ws.ReceiveAsync(_segments, CancellationToken.None).Result;
                            count += _receiveResult.Count;
                        }
                        string _message = Encoding.UTF8.GetString(buffer, 0, count);
                        OnMessage?.Invoke(_message);
                    }
                    catch (Exception e)
                    {
                        _log($"An error occured on server: {e.Message}");
                        break;
                    }
                }
            }
        }
        #endregion
    }
}
