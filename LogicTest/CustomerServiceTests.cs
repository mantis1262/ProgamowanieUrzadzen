using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Logic.Services;
using Logic.Dto;

namespace LogicTest
{
    [TestClass]
    public class CustomerServiceTests
    {

        [TestMethod]
        public void CreateCustomerServiceTest()
        {
            CustomerService customerService = new CustomerService();
            Assert.IsNotNull(customerService);
        }

        [TestMethod]
            public void GetSaveCustomerTest()
            {
                CustomerService customerService = new CustomerService();
                CustomerDto customerDto = new CustomerDto("0","Jan Kowalski", "Pierwszy 1/3", 123456789, "1234567890", "12345678900");
                customerService.SaveCustomer(customerDto);
                Assert.IsNotNull(customerService.GetCustomer("0"));
        }
    }
}
