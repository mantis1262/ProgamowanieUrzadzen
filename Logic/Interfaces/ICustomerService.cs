using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interfaces
{
    public interface ICustomerService
    {
        CustomerDto GetCustomer(string id);
        void SaveCustomer(CustomerDto customer);
    }
}
