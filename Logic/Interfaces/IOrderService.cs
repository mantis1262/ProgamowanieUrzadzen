using Logic.Dto;
using Logic.Events;
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
        void GiveDiscount(object sender, DiscountEvent e);
    }
}
