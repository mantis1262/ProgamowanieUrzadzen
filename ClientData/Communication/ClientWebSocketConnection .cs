﻿using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientData.Communication
{
    public class ClientWebSocketConnection : WebSocketConnection
    {
        private ClientWebSocket _clientWebSocket = null;
        private Uri _peer = null;
        private readonly Action<string> _log;

        public ClientWebSocketConnection(ClientWebSocket clientWebSocket, Uri peer, Action<string> log)
        {
            _clientWebSocket = clientWebSocket;
            _peer = peer;
            _log = log;
            Task.Factory.StartNew(() => ClientMessageLoop());
        }

        protected override Task SendTask(string message)
        {
            return _clientWebSocket.SendAsync(message.GetArraySegment(), WebSocketMessageType.Text, true, CancellationToken.None); ;
        }

        public override Task DisconnectAsync()
        {
            return _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Shutdown procedure started", CancellationToken.None);
        }

        public override string ToString()
        {
            return _peer.ToString();
        }

        public void ClientMessageLoop()
        {
            try
            {
                byte[] buffer = new byte[1024];
                while (true)
                {
                    ArraySegment<byte> segment = new ArraySegment<byte>(buffer);
                    WebSocketReceiveResult result = _clientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        OnClose?.Invoke();
                        _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "I am closing", CancellationToken.None).Wait();
                        return;
                    }
                    int count = result.Count;
                    while (!result.EndOfMessage)
                    {
                        if (count >= buffer.Length)
                        {
                           OnClose?.Invoke();
                            _clientWebSocket.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None).Wait();
                            return;
                        }
                        segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                        result = _clientWebSocket.ReceiveAsync(segment, CancellationToken.None).Result;
                        count += result.Count;
                    }
                    string _message = Encoding.UTF8.GetString(buffer, 0, count);
                    OnMessage?.Invoke(_message);
                }
            }
            catch (Exception e)
            {
                _log($"Connection has been broken because of an exception {e.Message}");
                _clientWebSocket.CloseAsync(WebSocketCloseStatus.InternalServerError, "Connection has been broken because of an exception", CancellationToken.None).Wait();
            }
        }
    }
}