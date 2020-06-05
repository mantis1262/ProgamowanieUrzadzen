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
    public class CustomerRepositoryTest
    {
        DataContext dataContext;
        CustomerRepository CustromerRepository;

        [TestInitialize]
        public void InitTest()
        {
             dataContext = new DataContext { Customers = new Dictionary<string, Customer>() };
             CustromerRepository = new CustomerRepository(dataContext);
        }


        [TestMethod]
        public void CreateTest()
        {
            Assert.IsNotNull(CustromerRepository);
        }

        [TestMethod]
        public void GetTest()
        {
            IEnumerable<Customer> Customer = CustromerRepository.Get();
            Assert.IsNotNull(Customer);
        }
        [TestMethod]
        public void AddTest()
        {
            Customer customer = new Customer
            { Id = "0",
                Name = "Jan Kowaslki",
                Address = "Pierwszego 2/4",
                Nip = "1234567890",
                Pesel = "12345678900",
                PhoneNumber = 123456789                
            };

            CustromerRepository.Add(customer);
            Assert.IsNotNull(CustromerRepository.Get("0"));
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

            CustromerRepository.Add(customer);
            CustromerRepository.Delete("0");

            Assert.AreEqual(0, CustromerRepository.Get().ToList().Count());
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

            CustromerRepository.Add(customer);

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

            CustromerRepository.Update("0", customer2);
            Assert.AreEqual(newPhone, CustromerRepository.Get("0").PhoneNumber);
        }
    }
}
