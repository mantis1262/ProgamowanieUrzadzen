using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Api
{
    interface ClientDataLayer
    {
        Order GetOrder(string id);

        string SendOrder(Order order);

        void ConfirmDelivery(string id, DateTime dateTime);
    }
}
