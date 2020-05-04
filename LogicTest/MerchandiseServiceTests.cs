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
    public class MerchandiseServiceTests
    {
        [TestMethod]
        public void CreateMerchandiseServiceTest()
        {
            MerchandiseService customerService = new MerchandiseService();
            Assert.IsNotNull(customerService);
        }

        [TestMethod]
        public void SaveCustomerTest()
        {
            MerchandiseService merchandiseService = new MerchandiseService();
            MerchandiseDto merchandiseDto = new MerchandiseDto("0","Jajao","Produkt wiejski",ArticleType.GROCERIES.ToString(),ArticleUnit.PACK.ToString(),13.20,0.01);
            merchandiseService.SaveMerchanise(merchandiseDto);
            Assert.AreEqual(1,merchandiseService.GetMerchandises().Count());
        }

        [TestMethod]
        public void GetCustomerTest()
        {
            MerchandiseService merchandiseService = new MerchandiseService();
            MerchandiseDto merchandiseDto = new MerchandiseDto("0", "Jajao", "Produkt wiejski", ArticleType.GROCERIES.ToString(), ArticleUnit.PACK.ToString(), 13.20, 0.01);
            merchandiseService.SaveMerchanise(merchandiseDto);
            Assert.IsNotNull(merchandiseService.GetMerchandise("0"));
        }
    }
}
