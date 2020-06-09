using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientData.Respositories;
using ClientData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientData.Model;
using Moq;
using ClientData;

namespace ClientDataTests
{
    [TestClass()]
    public class RepositoryTest
    {


        Mock<DataContext> dataContext;
        IRepository repository;
            [TestInitialize]
        public void InitTest()
        {
            Customer customer = new Customer("CLIENT_1", "Adam Nowak", "Polska 1/2", 123456789, "1234567890", "123456789000");
            List <Merchandise> merchandises = new List<Merchandise>() { new Merchandise("PRO_1", "RTV", "opis", ArticleType.AGD, ArticleUnit.KILOS, 2000.01, 0.10)};
            List<Entry> entries = new List<Entry>() { new Entry(1, merchandises[0], 10, 2200.20) };
            Order order = new Order("ORDER_1", customer, entries, Status.ACCEPTED, DateTime.Now, DateTime.Now);

            dataContext = new Mock<DataContext>(customer, merchandises, order);
            repository = new Repository(dataContext.Object);


        }

        [TestMethod()]
        public void GetCurrentCustomerTest()
        {
            Customer customer = repository.GetCurrentCustomer();
            Assert.AreEqual("CLIENT_1", customer.Id);
        }

        [TestMethod()]
        public void GetMerchandisesTest()
        {
           IList<Merchandise> merchandise = repository.GetMerchandises();
            Assert.AreEqual(1, merchandise.Count);
        }

        [TestMethod()]
        public void GetCurrentOrderTest()
        {
            Order order = repository.GetCurrentOrder();
            Assert.AreEqual("ORDER_1", order.Id);
        }
    }
}