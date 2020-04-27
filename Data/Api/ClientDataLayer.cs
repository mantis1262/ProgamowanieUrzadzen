using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Api
{
    public interface ClientDataLayer
    {
        ClientContactInfo GetClientInfo(string id);

        List<Merchandise> GetMerchandises();

        Order GetOrder(string id);

        string SubmitOrder(Order order);

        string ConfirmDelivery(string id, DateTime dateTime);
    }
}
