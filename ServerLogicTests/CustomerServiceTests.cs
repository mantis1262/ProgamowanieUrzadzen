using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using ServerLogic.Services;
using ServerLogic.Dto;
using System.Threading.Tasks;

namespace ServerLogicTests
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
            CustomerDto customerDto = new CustomerDto("","Jan Kowalski", "Pierwszy 1/3", 123456789, "1234567890", "12345678900");
            await customerService.SaveCustomer(customerDto);
            CustomerDto gotCustomerDto = await customerService.GetCustomer("CLIENT_1");
            Assert.IsNotNull(gotCustomerDto);
        }
    }
}
