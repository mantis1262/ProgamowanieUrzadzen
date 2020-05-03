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
    public class MerchandiseRepositoryTest
    {
        DataContext dataContext;
        MerchandiseRepository MerchandiseRepository;

        [TestInitialize]
        public void InitTest()
        {
             dataContext = new DataContext { Merchandises = new Dictionary<string, Merchandise>() };
            MerchandiseRepository = new MerchandiseRepository(dataContext);
        }


        [TestMethod]
        public void CreateTest()
        {
            Assert.IsNotNull(MerchandiseRepository);
        }

        [TestMethod]
        public void GetTest()
        {
            IEnumerable<Merchandise> Merchandises = MerchandiseRepository.Get();
            Assert.IsNotNull(Merchandises);
        }
        [TestMethod]
        public void AddTest()
        {
            Merchandise jajko = new Merchandise
            { Id = "0",
                Name = "Jajko",
                Description = "Produkty wiejski.",
                Type = ArticleType.GROCERIES,
                Unit = ArticleUnit.PACK,
                Vat = 0.08,
                NettoPrice = 12.40                         
            };

            MerchandiseRepository.Add(jajko);
            Assert.IsNotNull(MerchandiseRepository.Get("0"));
        }
        [TestMethod]
        public void DeleteTest()
        {

            Merchandise jajko = new Merchandise
            {
                Id = "0",
                Name = "Jajko",
                Description = "Produkty wiejski.",
                Type = ArticleType.GROCERIES,
                Unit = ArticleUnit.PACK,
                Vat = 0.08,
                NettoPrice = 12.40
            };

            MerchandiseRepository.Add(jajko);
            MerchandiseRepository.Delete("0");

            Assert.AreEqual(0, MerchandiseRepository.Get().ToList().Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            Merchandise jajko = new Merchandise
            {
                Id = "0",
                Name = "Jajko",
                Description = "Produkty wiejski.",
                Type = ArticleType.GROCERIES,
                Unit = ArticleUnit.PACK,
                Vat = 0.08,
                NettoPrice = 12.40
            };

            MerchandiseRepository.Add(jajko);

            double newPrice = 13.50;
            Merchandise jajko2 = new Merchandise
            {
                Id = "0",
                Name = "Jajko",
                Description = "Produkty wiejski.",
                Type = ArticleType.GROCERIES,
                Unit = ArticleUnit.PACK,
                Vat = 0.08,
                NettoPrice = newPrice
            };


            MerchandiseRepository.Update("0", jajko2);
            Assert.AreEqual(newPrice, MerchandiseRepository.Get("0").NettoPrice);
        }
    }
}
