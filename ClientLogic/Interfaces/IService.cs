using ClientLogic.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLogic.Interfaces
{
    public interface IService
    {
        Task<CustomerDto> GetCurrentCustomer(string customerId);
        Task<IList<MerchandiseDto>> GetMerchandises();
        Task<OrderDto> GetCurrentOrder(string orderId);
    }
}
