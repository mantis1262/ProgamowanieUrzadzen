using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Api
{
    interface ClientLogicLayer
    {
        ClientDto GetClient(string id);

        List<MerchandiseDto> GetMerchandises();

        OrderDto GetOrder(string id);

        string SubmitOrder(OrderDto orderDto);

        string ConfirmDelivery(string id, DateTime dateTime);
    }
}
