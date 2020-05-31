using System;
using Logic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicClientTest
{
    [TestClass]
    public class ClientWebSocketServicesTest
    {
        [TestMethod]
        public void CreateClientWebSocketServicesTest()
        {
            ClientWebSocetServices webSocetServices = new ClientWebSocetServices();
            Assert.IsNotNull(webSocetServices);
        }
    }
}
