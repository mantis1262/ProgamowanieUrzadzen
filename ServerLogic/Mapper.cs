using ServerData.Model;
using ServerLogic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerLogic
{
    public static class Mapper
    {
        public static CustomerDto ToDto(this Customer clientInfo)
        {
            return new CustomerDto
                (
                    clientInfo.Id, 
                    clientInfo.Name, 
                    clientInfo.Address, 
                    clientInfo.PhoneNumber, 
                    clientInfo.Nip, 
                    clientInfo.Pesel
                );
        }

        public static MerchandiseDto ToDto(this Merchandise merchandise)
        {
            return new MerchandiseDto
                (
                    merchandise.Id,
                    merchandise.Name,
                    merchandise.Description,
                    merchandise.Type.ToString(),
                    merchandise.Unit.ToString(),
                    merchandise.NettoPrice,
                    merchandise.Vat
                );
        }

        public static List<MerchandiseDto> ToDto(this List<Merchandise> merchandises)
        {
            List<MerchandiseDto> result = new List<MerchandiseDto>();
            foreach (Merchandise merchandise in merchandises)
            {
                result.Add(merchandise.ToDto());
            }

            return result;
        }

        public static EntryDto ToDto(this Entry entry)
        {
            return new EntryDto
                (
                    entry.Id,
                    entry.Merchandise.ToDto(),
                    entry.Amount,
                    entry.BruttoPrice,
                    entry.Amount * entry.BruttoPrice
                );
        }

        public static List<EntryDto> ToDto(this List<Entry> entries)
        {
            List<EntryDto> result = new List<EntryDto>();
            foreach (Entry entry in entries)
            {
                result.Add(entry.ToDto());
            }

            return result;
        }

        public static OrderDto ToDto(this Order order)
        {
            double totalBruttoPrice = 0;

            foreach (Entry entry in order.Entries)
            {
                totalBruttoPrice += entry.Amount * entry.BruttoPrice;
            }

            return new OrderDto
                (
                    order.Id,
                    order.Client.ToDto(),
                    order.Entries.ToDto(),
                    order.Status.ToString(),
                    totalBruttoPrice,
                    order.AcceptanceDate.Ticks,
                    order.DeliveringDate.Ticks
                );
        }

        public static Customer FromDto(this CustomerDto clientDto)
        {
            return new Customer
                (
                    clientDto.Id,
                    clientDto.Name,
                    clientDto.Address,
                    clientDto.PhoneNumber,
                    clientDto.Nip,
                    clientDto.Pesel
                );
        }

        public static Merchandise FromDto(this MerchandiseDto merchandiseDto)
        {
            Enum.TryParse(merchandiseDto.Type, out ArticleType type);
            Enum.TryParse(merchandiseDto.Unit, out ArticleUnit unit);

            return new Merchandise
                (
                    merchandiseDto.Id,
                    merchandiseDto.Name,
                    merchandiseDto.Description,
                    type,
                    unit,
                    merchandiseDto.NettoPrice,
                    merchandiseDto.Vat
                );
        }

        public static List<Merchandise> FromDto(this List<MerchandiseDto> merchandisesDto)
        {
            List<Merchandise> result = new List<Merchandise>();
            foreach (MerchandiseDto merchandiseDto in merchandisesDto)
            {
                result.Add(merchandiseDto.FromDto());
            }

            return result;
        }

        public static Entry FromDto(this EntryDto entryDto)
        {
            return new Entry
                (
                    entryDto.Id,
                    entryDto.Merchandise.FromDto(),
                    entryDto.Amount,
                    entryDto.BruttoPrice
                );
        }

        public static List<Entry> FromDto(this List<EntryDto> entriesDto)
        {
            List<Entry> result = new List<Entry>();
            foreach (EntryDto entryDto in entriesDto)
            {
                result.Add(entryDto.FromDto());
            }

            return result;
        }

        public static Order FromDto(this OrderDto orderDto)
        {
            Enum.TryParse(orderDto.Status, out Status status);

            return new Order
                (
                    orderDto.Id,
                    orderDto.ClientInfo.FromDto(),
                    orderDto.Entries.FromDto(),
                    status,
                    new DateTime(orderDto.AcceptanceDate),
                    new DateTime(orderDto.DeliveringDate)
                );
        }
    }
}
