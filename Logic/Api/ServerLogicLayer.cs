using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Api
{
    interface ServerLogicLayer
    {
        ClientDto SendClientInfo(string id);

        List<MerchandiseDto> SendMerchandises();

        OrderDto SendOrder(string id);

        string SaveOrder(OrderDto order);

        string CloseOrder(string id, DateTime dateTime);
    }
}
