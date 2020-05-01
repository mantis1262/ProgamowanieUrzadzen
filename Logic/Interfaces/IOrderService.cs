using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interfaces
{
    public interface IOrderService
    {
        OrderDto GetOrder(string id);
        void SaveOrder(OrderDto order);
        void CancelOrder(string id);
    }
}
