using ServerLogic.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerLogic.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomer(string id);
        Task<string> SaveCustomer(CustomerDto customer);
    }
}
