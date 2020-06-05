using ServerLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerPresentation
{
    public class CommunicationManager : IDisposable
    {
        private Action<string> _log { get; }

        private int _websocketPort = 8081;

        private List<WebSocketConnection> _sockets { get; set; } = new List<WebSocketConnection>();

        private MessageResolver _messageResolver;

        public CommunicationManager(int websocketPort, OrderService orderService, Action<string> log)
        {
            _log = log;
            _messageResolver = new MessageResolver(orderService, log);
            if (IPEndPoint.MaxPort > websocketPort && IPEndPoint.MinPort < websocketPort)
                _websocketPort = websocketPort;
            else
                _log($"Incorrect port number. System will use default port {_websocketPort}");
        }

        public async Task InitServerAsync()
        {
            _log($"Web socket server listening on port: {_websocketPort}");
            await WebSocketServer.Server(_websocketPort, async _ws => await InitConnectionAsync(_ws), _log);
        }

        private async Task InitConnectionAsync(WebSocketConnection ws)
        {
            _sockets.Add(ws);
            InitMessageHandler(ws);
            InitErrorHandler(ws);
            await WriteAsync(ws, "Connected");
        }

        private void InitErrorHandler(WebSocketConnection ws)
        {
            ws.OnClose = () => CloseConnection(ws);
            ws.OnError = () => CloseConnection(ws);
        }

        private void CloseConnection(WebSocketConnection ws)
        {
            _log($"Closing connection to peer: {ws}");
            _sockets.Remove(ws);
        }

        private async Task WriteAsync(WebSocketConnection ws, string message)
        {
            _log($"[Sending message]: {message}");
            await ws.SendAsync(message);
        }

        private void InitMessageHandler(WebSocketConnection ws)
        {
            ws.OnMessage = async (data) =>
            {
                _log($"[Received message]: {data}");
                await ws.SendAsync(await _messageResolver.Resolve(data, ws));
            };
        }

        public void Dispose()
        {
            _log($"Shuting down the communication manager");
            List<Task> _disconnectionTasks = new List<Task>();
            foreach (WebSocketConnection _item in _sockets)
                _disconnectionTasks.Add(_item.DisconnectAsync());
            Task.WaitAll(_disconnectionTasks.ToArray());
        }
    }
}
