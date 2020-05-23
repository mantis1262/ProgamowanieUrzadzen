using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomer(string id);
        Task SaveCustomer(CustomerDto customer);
    }
}
