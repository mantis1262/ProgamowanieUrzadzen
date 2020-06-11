using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientData;
using ClientData.Model;
using ClientData.Respositories;
using ClientLogic.Dto;
using ClientLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicClientTest
{
    [TestClass]
    public class ManageDataServiceTest
    {
        string _uriPeer = "ws://localhost:8081/";

        [TestMethod]
        public void CreateManageDataServiceTest()
        {
            ManageDataService manageDataService = new ManageDataService((mesg) => { }, _uriPeer);
            Assert.IsNotNull(manageDataService);
        }

        [TestMethod]
        public async Task GetCustomerTest()
        {
            DataContext dataContext = new DataContext();
            Customer customer = new Customer("CLIENT_1", "Jan Kowalski", "Pierwszy 1/3", 123456789, "1234567890", "12345678900");
            dataContext.CurrentCustomer = customer;
            Repository repository = new Repository(dataContext);
            ManageDataService manageDataService = new ManageDataService(repository, (mesg) => { }, _uriPeer);
            Assert.IsNotNull(await manageDataService.GetCurrentCustomer());
            Assert.AreEqual((await manageDataService.GetCurrentCustomer()).Id, customer.Id);
        }

        [TestMethod]
        public async Task GetMerchandisesTest()
        {
            DataContext dataContext = new DataContext();
            Merchandise merchandise1 = new Merchandise("0", "Jajao", "Produkt wiejski", ArticleType.GROCERIES, ArticleUnit.PACK, 13.20, 0.01);
            Merchandise merchandise2 = new Merchandise("1", "Chleb", "Artykuły spożywcze", ArticleType.GROCERIES, ArticleUnit.PIECE, 5.20, 0.05);
            List<Merchandise> merchandises = new List<Merchandise>();
            merchandises.Add(merchandise1);
            merchandises.Add(merchandise2);
            dataContext.Merchandises = merchandises;
            Repository repository = new Repository(dataContext);
            ManageDataService manageDataService = new ManageDataService(repository, (mesg) => { }, _uriPeer);
            Assert.IsNotNull(await manageDataService.GetMerchandises());
            Assert.AreEqual((await manageDataService.GetMerchandises()).Count, 2);
        }

        [TestMethod]
        public async Task GetCurrentOrder()
        {
            DataContext dataContext = new DataContext();
            Customer customer = new Customer("CLIENT_1", "Jan Kowalski", "Pierwszy 1/3", 123456789, "1234567890", "12345678900");
            dataContext.CurrentCustomer = customer;
            Merchandise merchandise1 = new Merchandise("0", "Jajao", "Produkt wiejski", ArticleType.GROCERIES, ArticleUnit.PACK, 13.20, 0.01);
            Merchandise merchandise2 = new Merchandise("1", "Chleb", "Artykuły spożywcze", ArticleType.GROCERIES, ArticleUnit.PIECE, 5.20, 0.05);
            List<Merchandise> merchandises = new List<Merchandise>();
            merchandises.Add(merchandise1);
            merchandises.Add(merchandise2);
            dataContext.Merchandises = merchandises;
            Entry entry1 = new Entry(1, merchandise1, 2, 10);
            Entry entry2 = new Entry(2, merchandise2, 5, 30);
            List<Entry> entires = new List<Entry>();
            entires.Add(entry1);
            entires.Add(entry2);
            Order order = new Order(
                "0",
                customer,
                entires,
                Status.ACCEPTED,
                new DateTime(2020, 01, 01),
                new DateTime(2020, 03, 01)
            );
            dataContext.CurrentOrder = order;
            Repository repository = new Repository(dataContext);
            ManageDataService manageDataService = new ManageDataService(repository, (mesg) => { }, _uriPeer);
            Assert.IsNotNull(await manageDataService.GetCurrentOrder());
            OrderDto orderDto = await manageDataService.GetCurrentOrder();
            Assert.AreEqual(orderDto.Entries.Count, 2);
        }
    }
}
