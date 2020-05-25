using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Logic.Services;
using Logic.Dto;
using System.Threading.Tasks;

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
        public async Task GetSaveCustomerTest()
        {
            CustomerService customerService = new CustomerService();
            CustomerDto customerDto = new CustomerDto("0","Jan Kowalski", "Pierwszy 1/3", 123456789, "1234567890", "12345678900");
            await customerService.SaveCustomer(customerDto);
            CustomerDto gotCustomerDto = await customerService.GetCustomer("0");
            Assert.IsNotNull(gotCustomerDto);
        }
    }
}
