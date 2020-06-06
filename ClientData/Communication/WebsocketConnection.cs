using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientData.Communication
{
    public abstract class WebSocketConnection
    {
        public WebSocket WebSocket = null;
        public virtual Action<string> OnMessage { set; protected get; } = x => { };
        public virtual Action OnClose { set; protected get; } = () => { };
        public virtual Action OnError { set; protected get; } = () => { };

        public async Task SendAsync(string message)
        {
            await SendTask(message);
        }

        protected abstract Task SendTask(string message);

        public abstract Task DisconnectAsync();
    }
}
