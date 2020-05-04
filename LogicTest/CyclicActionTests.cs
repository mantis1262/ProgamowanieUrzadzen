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
    public class CyclicActionTests
    {
        [TestMethod]
        public void CreateCyclicActtionServiceTest()
        {
            CyclicActionService cyclicActionService = new CyclicActionService(TimeSpan.Zero);
            Assert.IsNotNull(cyclicActionService);
        }
    }
}
