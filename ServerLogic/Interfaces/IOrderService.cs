using ServerLogic.Dto;
using ServerLogic.Observer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerLogic.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrder(string id);
        Task<string> SaveOrder(OrderDto order);
        Task CancelOrder(string id);
        Task<IDisposable> Subscribe(IObserver<DiscountEvent> observer);
        Task<IList<IObserver<DiscountEvent>>> GetSubscribers();
    }
}
