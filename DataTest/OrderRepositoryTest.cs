using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repositories;
using Data.Model;

namespace DataTest
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
                 
            };

            OrderRepository.Add(customer);
            Assert.IsNotNull(OrderRepository.Get("0"));
        }
        [TestMethod]
        public void DeleteTest()
        {

            Customer customer = new Customer
            {
                Id = "0",
                Name = "Jan Kowaslki",
                Address = "Pierwszego 2/4",
                Nip = "1234567890",
                Pesel = "12345678900",
                PhoneNumber = 123456789
            };

            OrderRepository.Add(customer);
            OrderRepository.Delete("0");

            Assert.AreEqual(0, OrderRepository.Get().ToList().Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            Customer customer = new Customer
            {
                Id = "0",
                Name = "Jan Kowaslki",
                Address = "Pierwszego 2/4",
                Nip = "1234567890",
                Pesel = "12345678900",
                PhoneNumber = 123456789
            };

            OrderRepository.Add(customer);

            int newPhone = 987654321;
            Customer customer2 = new Customer
            {
                Id = "0",
                Name = "Jan Kowaslki",
                Address = "Pierwszego 2/4",
                Nip = "1234567890",
                Pesel = "12345678900",
                PhoneNumber = newPhone
            };

            OrderRepository.Update("0", customer2);
            Assert.AreEqual(newPhone, OrderRepository.Get("0").PhoneNumber);
        }
    }
}
