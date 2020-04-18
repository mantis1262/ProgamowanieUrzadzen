using Data.Model.Contact;
using Data.Model.Orders;
using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Mapper
{
    public static class ModelMapper
    {
        public static ClientApiDto ClientToApiDto(Client client)
        {
            return new ClientApiDto(
                    client.Name,
                    client.Address,
                    client.PhoneNumber,
                    client.Nip,
                    client.Pesel
                );
        }

        public static SupplierApiDto SupplierToApiDto(Supplier supplier)
        {
            return new SupplierApiDto(
                    supplier.Name,
                    supplier.Address,
                    supplier.Nip
                );
        }

        public static EntryApiDto EntryToApiDto(Entry entry)
        {
            return new EntryApiDto(
                    entry.Number,
                    entry.Merchandise.Name,
                    entry.Merchandise.Description,
                    entry.Merchandise.Type.ToString(),
                    entry.Merchandise.Unit.ToString(),
                    entry.Merchandise.Supplier.Name,
                    entry.Amount,
                    entry.BruttoPrice,
                    entry.Amount * entry.BruttoPrice
                );
        }

        public static OrderApiDto OrderToApiDto(Order order)
        {
            List<EntryApiDto> entries = new List<EntryApiDto>();
            double totalBruttoPrice = 0;
            foreach (Entry entry in order.Entries)
            {
                totalBruttoPrice += entry.BruttoPrice;
                entries.Add(EntryToApiDto(entry));
            }

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
