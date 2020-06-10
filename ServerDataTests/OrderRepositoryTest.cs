using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using ServerData;
using ServerData.Repositories;
using ServerData.Model;

namespace ServerDataTests
{
    [TestClass]
    public class OrderRepositoryTest
    {
        DataContext dataContext;
        OrderRepository OrderRepository;

        [TestInitialize]
        public void InitTest()
        {
            dataContext = new DataContext { Orders = new Dictionary<string, Order>() };
            OrderRepository = new OrderRepository(dataContext);
        }


        [TestMethod]
        public void CreateTest()
        {
            Assert.IsNotNull(OrderRepository);
        }

        [TestMethod]
        public void GetTest()
        {
            IEnumerable<Order> orders = OrderRepository.Get();
            Assert.IsNotNull(orders);
        }
        [TestMethod]
        public void AddTest()
        {

            Order order = new Order
            { Id = "0",
                AcceptanceDate = new DateTime(2020, 01, 05),
                Client = new Customer(),
                DeliveringDate = new DateTime(),
                Entries = new List<Entry>(),
                Status = Status.IN_PROGRESS
            };

            OrderRepository.Add(order);
            Assert.IsNotNull(OrderRepository.Get("0"));
        }
        [TestMethod]
        public void DeleteTest()
        {

            Order order = new Order
            {
                Id = "0",
                AcceptanceDate = new DateTime(2020, 01, 05),
                Client = new Customer(),
                DeliveringDate = new DateTime(),
                Entries = new List<Entry>(),
                Status = Status.IN_PROGRESS
            };

            OrderRepository.Add(order);
            OrderRepository.Delete("0");

            Assert.AreEqual(0, OrderRepository.Get().ToList().Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            Order order = new Order
            {
                Id = "0",
                AcceptanceDate = new DateTime(2020, 01, 05),
                Client = new Customer(),
                DeliveringDate = new DateTime(),
                Entries = new List<Entry>(),
                Status = Status.IN_PROGRESS
            };

            OrderRepository.Add(order);

            Order order2 = new Order
            {
                Id = "0",
                AcceptanceDate = new DateTime(2020, 01, 05),
                Client = new Customer(),
                DeliveringDate = new DateTime(),
                Entries = new List<Entry>(),
                Status = Status.ACCEPTED
            };

            OrderRepository.Update("0", order2);
            Assert.AreEqual(Status.ACCEPTED, OrderRepository.Get("0").Status);
        }
    }
}
