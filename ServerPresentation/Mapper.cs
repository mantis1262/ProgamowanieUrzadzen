using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;
using Communication.Model;
using ServerLogic;
using ServerLogic.Dto;

namespace ServerPresentation
{
    public static class Mapper
    {
        public static CustomerDto ToDto(this CustomerModel customerModel)
        {
            return new CustomerDto
                (
                    customerModel.Id,
                    customerModel.Name,
                    customerModel.Address,
                    customerModel.PhoneNumber,
                    customerModel.Nip,
                    customerModel.Pesel
                );
        }

        public static MerchandiseDto ToDto(this MerchandiseModel merchandiseModel)
        {
            return new MerchandiseDto
                (
                    merchandiseModel.Id,
                    merchandiseModel.Name,
                    merchandiseModel.Description,
                    merchandiseModel.Type,
                    merchandiseModel.Unit.ToString(),
                    merchandiseModel.NettoPrice,
                    merchandiseModel.Vat
                );
        }

        public static List<MerchandiseDto> ToDto(this List<MerchandiseModel> merchandisesModels)
        {
            List<MerchandiseDto> result = new List<MerchandiseDto>();
            foreach (MerchandiseModel merchandise in merchandisesModels)
            {
                result.Add(merchandise.ToDto());
            }

            return result;
        }

        public static EntryDto ToDto(this EntryModel entryDto)
        {
            return new EntryDto
                (
                    entryDto.Id,
                    entryDto.Merchandise.ToDto(),
                    entryDto.Amount,
                    entryDto.BruttoPrice,
                    CalcHelper.GetTotalBrutto(entryDto.BruttoPrice, entryDto.Amount)
                );
        }

        public static List<EntryDto> ToDto(this List<EntryModel> entriesModels)
        {
            List<EntryDto> result = new List<EntryDto>();
            foreach (EntryModel entry in entriesModels)
            {
                result.Add(entry.ToDto());
            }

            return result;
        }

        public static OrderDto ToDto(this OrderModel orderModel)
        {
            return new OrderDto
                (
                    orderModel.Id,
                    orderModel.ClientInfo.ToDto(),
                    orderModel.Entries.ToDto(),
                    orderModel.Status,
                    CalcHelper.GetTotalBrutto(orderModel.Entries),
                    orderModel.AcceptanceDate,
                    orderModel.DeliveringDate
                );
        }

        public static CustomerModel FromDto(this CustomerDto customerDto)
        {
            return new CustomerModel
                (
                    customerDto.Id,
                    customerDto.Name,
                    customerDto.Address,
                    customerDto.PhoneNumber,
                    customerDto.Nip,
                    customerDto.Pesel
                );
        }

        public static MerchandiseModel FromDto(this MerchandiseDto merchandiseDto)
        {
            return new MerchandiseModel
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

        public static List<MerchandiseModel> FromDto(this List<MerchandiseDto> merchandiseDtos)
        {
            List<MerchandiseModel> result = new List<MerchandiseModel>();
            foreach (MerchandiseDto merchandise in merchandiseDtos)
            {
                result.Add(merchandise.FromDto());
            }

            return result;
        }

        public static EntryModel FromDto(this EntryDto entryDto)
        {
            return new EntryModel
                (
                    entryDto.Id,
                    entryDto.Merchandise.FromDto(),
                    entryDto.Amount,
                    entryDto.BruttoPrice
                );
        }

        public static List<EntryModel> FromDto(this List<EntryDto> entriesDtos)
        {
            List<EntryModel> result = new List<EntryModel>();
            foreach (EntryDto entry in entriesDtos)
            {
                result.Add(entry.FromDto());
            }

            return result;
        }

        public static OrderModel FromDto(this OrderDto orderDto)
        {
            return new OrderModel
                (
                    orderDto.Id,
                    orderDto.ClientInfo.FromDto(),
                    orderDto.Entries.FromDto(),
                    orderDto.Status,
                    orderDto.AcceptanceDate,
                    orderDto.DeliveringDate
                );
        }
    }
}
