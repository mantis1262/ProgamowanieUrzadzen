using ClientLogic.Dto;
using ClientPresentation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPresentation
{
    public static class Mapper
    {
        public static CustomerDto ToDto(this Customer customer)
        {
            return new CustomerDto
                (
                    customer.Id,
                    customer.Name,
                    customer.Address,
                    customer.PhoneNumber,
                    customer.Nip,
                    customer.Pesel
                );
        }

        public static MerchandiseDto ToDto(this Product product)
        {
            return new MerchandiseDto
                (
                    product.Id,
                    product.Name,
                    product.Description,
                    product.Type.ToString(),
                    product.Unit.ToString(),
                    product.NettoPrice,
                    product.Vat
                );
        }

        public static List<MerchandiseDto> ToDto(this List<Product> merchandises)
        {
            List<MerchandiseDto> result = new List<MerchandiseDto>();
            foreach (Product merchandise in merchandises)
            {
                result.Add(merchandise.ToDto());
            }

            return result;
        }

        public static EntryDto ToDto(this Entry entry)
        {
            MerchandiseDto merchandiseDto = new MerchandiseDto
            (
                entry.Code, 
                entry.Name, 
                entry.Description,
                entry.Type,
                entry.Unit,
                entry.NettoPrice,
                entry.Vat
            );
            return new EntryDto
                (
                    entry.Id,
                    merchandiseDto,
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

        public static OrderDto ToDto(this OrderSummary order, Customer customer, List<Entry> entries)
        {
            double totalBruttoPrice = 0;

            foreach (Entry entry in entries)
            {
                totalBruttoPrice += entry.Amount * entry.BruttoPrice;
            }

            return new OrderDto
                (
                    order.Id,
                    customer.ToDto(),
                    entries.ToDto(),
                    order.Status,
                    totalBruttoPrice,
                    order.SubmittedDate.Ticks,
                    order.DeliveredDate.Ticks
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

        public static Product FromDto(this MerchandiseDto merchandiseDto)
        {
            return new Product
                (
                    merchandiseDto.Id,
                    merchandiseDto.Name,
                    merchandiseDto.Description,
                    merchandiseDto.Type,
                    merchandiseDto.Unit,
                    merchandiseDto.NettoPrice,
                    merchandiseDto.Vat
                );
        }

        public static List<Product> FromDto(this List<MerchandiseDto> merchandisesDto)
        {
            List<Product> result = new List<Product>();
            foreach (MerchandiseDto productDto in merchandisesDto)
            {
                result.Add(productDto.FromDto());
            }

            return result;
        }

        public static Entry FromDto(this EntryDto entryDto)
        {
            return new Entry
                (
                    entryDto.Id,
                    entryDto.Merchandise.Id,
                    entryDto.Merchandise.Name,
                    entryDto.Merchandise.Description,
                    entryDto.Merchandise.Type,
                    entryDto.Merchandise.Unit,
                    entryDto.Merchandise.NettoPrice,
                    entryDto.Merchandise.Vat,
                    entryDto.Amount,
                    entryDto.BruttoPrice,
                    entryDto.TotalBruttoPrice
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

        public static OrderSummary FromDto(this OrderDto orderDto)
        {
            return new OrderSummary
                (
                    orderDto.Id,
                    orderDto.Status,
                    orderDto.TotalBruttoPrice,
                    new DateTime(orderDto.AcceptanceDate),
                    new DateTime(orderDto.DeliveringDate)
                );
        }
    }
}
