using ClientData.Communication;
using ClientData.Model;
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
        void CloseConnection();
        Task<Customer> AskForCustomer(string customerId);
        Task<IList<Merchandise>> AskForMerchandises();
        Task<Order> AskForOrder(string orderId);
        Task<string> ApplyOrder(OrderDto order);
        Task<string> AskForSubscription();
        Task<string> AskForUnsubscription();
    }
}
