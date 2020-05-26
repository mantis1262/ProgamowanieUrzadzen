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

namespace LogicTest
{
    [TestClass]
    public class CyclicDiscountTests
    {
        [TestMethod]
        public void TimerTest()
        {
            IMerchandiseService merchandiseService = new MerchandiseService();
            DiscountCreator discountCreator = new DiscountCreator(merchandiseService);
            CyclicDiscountService _timer = new CyclicDiscountService(10, TimeSpan.FromSeconds(1), discountCreator);
            
            Assert.IsNotNull(merchandiseService);
            Assert.IsNotNull(discountCreator);
            Assert.IsNotNull(_timer);
        }
    }
}
