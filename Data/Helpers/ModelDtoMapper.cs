using Data.Model;
using Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Helpers
{
    public static class ModelDtoMapper
    {
        public static ClientApiDto ClientToApiDto(ClientContactInfo client)
        {
            return new ClientApiDto(
                    client.Name,
                    client.Address,
                    client.PhoneNumber,
                    client.Nip,
                    client.Pesel
                );
        }

        public static EntryApiDto EntryToApiDto(Entry entry, double totalBruttoPrice)
        {
            return new EntryApiDto(
                    entry.Number,
                    entry.Merchandise.Name,
                    entry.Merchandise.Description,
                    entry.Merchandise.Type.ToString(),
                    entry.Merchandise.Unit.ToString(),
                    entry.Amount,
                    entry.BruttoPrice,
                    totalBruttoPrice
                );
        }

        public static OrderApiDto OrderToApiDto(Order order, List<EntryApiDto> entries, double totalBruttoPrice)
        {
            return new OrderApiDto(
                    order.Code,
                    ClientToApiDto(order.Client),
                    entries,
                    order.Status.ToString(),
                    totalBruttoPrice,
                    order.AcceptanceDate.Ticks,
                    order.SendingDate.Ticks,
                    order.DeliveringDate.Ticks
                );
        }
    }
}
