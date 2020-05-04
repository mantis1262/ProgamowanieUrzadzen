using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Logic.Services;
using Data.Model;
using Logic.Dto;

namespace LogicTest
{
    [TestClass]
    public class OrderServiceTests
    {
        [TestMethod]
        public void CreateOrderServiceTests()
        {
            OrderService orderService = new OrderService();
            Assert.IsNotNull(orderService);
        }

        [TestMethod]
        public void SaveOrderTest()
        {
            OrderService orderService = new OrderService();
            OrderDto orderDto = new OrderDto
                (
                "0",
                new CustomerDto("0","ola","lodzka 2",123456789,"1234567890","12345678900"),
                new List<EntryDto>(),
                Status.SENT.ToString(),
                40.04,
                new DateTime(2020, 01, 01).Ticks,
                new DateTime(2020, 03, 01).Ticks
            );
            orderService.SaveOrder(orderDto);
            Assert.IsNotNull(orderService.GetOrder("0"));
        }        
    }
}
