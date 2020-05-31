using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Logic.Services;
using Data.Model;
using Logic.Dto;
using Logic.Observer;
using System.Reactive.Linq;
using Logic.Interfaces;
using Moq;
using System.Security.Cryptography.X509Certificates;

namespace LogicTest
{
    [TestClass]
    public class CyclicDiscountTests
    {
        Mock<DiscountCreator> _discountCreator;
        CyclicDiscountService _timer;

        [TestInitialize]
        public void InitTest()
        {
            Mock<IMerchandiseService> merchandiseService = new Mock<IMerchandiseService>();

             _discountCreator = new Mock<DiscountCreator>(merchandiseService.Object);
             _timer = new CyclicDiscountService(10, TimeSpan.FromSeconds(1), _discountCreator.Object);
        }
        [TestMethod]
        public void CreateTest()
        {
            Assert.IsNotNull(_discountCreator);
            Assert.IsNotNull(_timer);
        }
    }
}
