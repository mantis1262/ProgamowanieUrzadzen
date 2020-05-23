using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Logic.Services;
using Data.Model;
using Logic.Dto;
using System.Threading.Tasks;

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
        public async Task SaveCustomerTest()
        {
            MerchandiseService merchandiseService = new MerchandiseService();
            MerchandiseDto merchandiseDto = new MerchandiseDto("0", "Jajao", "Produkt wiejski", ArticleType.GROCERIES.ToString(), ArticleUnit.PACK.ToString(), 13.20, 0.01);
            await merchandiseService.SaveMerchandise(merchandiseDto);
            List<MerchandiseDto> gotMerchandiseDtos = (await merchandiseService.GetMerchandises()).ToList();
            Assert.AreEqual(1, gotMerchandiseDtos.Count());
        }

        [TestMethod]
        public async Task GetCustomerTest()
        {
            MerchandiseService merchandiseService = new MerchandiseService();
            MerchandiseDto merchandiseDto = new MerchandiseDto("0", "Jajao", "Produkt wiejski", ArticleType.GROCERIES.ToString(), ArticleUnit.PACK.ToString(), 13.20, 0.01);
            await merchandiseService.SaveMerchandise(merchandiseDto);
            MerchandiseDto gotMerchandiseDto = await merchandiseService.GetMerchandise("0");
            Assert.IsNotNull(gotMerchandiseDto);
        }
    }
}
