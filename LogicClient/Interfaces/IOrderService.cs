using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrder(string id);
        Task<string> SaveOrder(OrderDto order);
        Task CancelOrder(string id);
    }
}
