using System;
using ClientData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClientDataTests
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
