using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Api
{
    interface ServerDataLayer
    {
        Order GetOrder(string id);

        string SaveOrder(Order order);

        void ModifyOrder(Order order);
    }
}
