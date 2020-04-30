using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Api
{
    public interface ServerDataLayer
    {
        ClientContactInfo SendClientInfo(string id);

        List<Merchandise> SendMerchandises();

        Order SendOrder(string id);

        string SaveClientInfo(ClientContactInfo client);

        string SaveOrder(Order order);

        string CloseOrder(string id, DateTime dateTime);

        void SendStatsOfDay(DailyStats dailyStats);
    }
}
