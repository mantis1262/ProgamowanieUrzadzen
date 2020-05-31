using System;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataClientTest
{
    [TestClass]
    public class WebSocketTest
    {
        [TestMethod]
        public void CreateWebSocket()
        {
            WebSocketClient webSocketClient = new WebSocketClient();
            Assert.IsNotNull(webSocketClient);
        }
    }
}
