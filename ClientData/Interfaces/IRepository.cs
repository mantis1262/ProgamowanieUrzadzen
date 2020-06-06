using ClientData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientData.Interfaces
{
    public interface IRepository
    {
        Customer GetCurrentCustomer();
        IList<Merchandise> GetMerchandises();
        Order GetCurrentOrder();
        void RefreshCurrentCustomer(Customer customer);
        void RefreshMerchandises(IList<Merchandise> merchandises);
        void RefreshCurrentOrder(Order order);
    }
}
