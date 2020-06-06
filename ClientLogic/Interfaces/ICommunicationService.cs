using ClientLogic.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLogic.Interfaces
{
    public interface ICommunicationService
    {
        Task CreateConnection();
        Task AskForCustomer(string customerId);
        Task AskForMerchandises();
        Task AskForOrder(string orderId);
        Task ApplyOrder(OrderDto order);
        Task AskForSubscription();
        Task AskForUnsubscription();
    }
}
