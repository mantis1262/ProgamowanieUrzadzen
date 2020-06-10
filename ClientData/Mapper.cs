using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientData.Model;
using Communication;
using Communication.Model;

namespace ServerPresentation
{
    public static class Mapper
    {
        public static Customer FromCommModel(this CustomerModel customerModel)
        {
            return new Customer
                (
                    customerModel.Id,
                    customerModel.Name,
                    customerModel.Address,
                    customerModel.PhoneNumber,
                    customerModel.Nip,
                    customerModel.Pesel
                );
        }

        public static Merchandise FromCommModel(this MerchandiseModel merchandiseModel)
        {
            Enum.TryParse(merchandiseModel.Type, out ArticleType type);
            Enum.TryParse(merchandiseModel.Unit, out ArticleUnit unit);

            return new Merchandise
                (
                    merchandiseModel.Id,
                    merchandiseModel.Name,
                    merchandiseModel.Description,
                    type,
                    unit,
                    merchandiseModel.NettoPrice,
                    merchandiseModel.Vat
                );
        }

        public static List<Merchandise> FromCommModel(this List<MerchandiseModel> merchandisesModels)
        {
            List<Merchandise> result = new List<Merchandise>();
            foreach (MerchandiseModel merchandise in merchandisesModels)
            {
                result.Add(merchandise.FromCommModel());
            }

            return result;
        }

        public static Entry FromCommModel(this EntryModel entryModel)
        {
            return new Entry
                (
                    entryModel.Id,
                    entryModel.Merchandise.FromCommModel(),
                    entryModel.Amount,
                    entryModel.BruttoPrice
                );
        }

        public static List<Entry> FromCommModel(this List<EntryModel> entriesModels)
        {
            List<Entry> result = new List<Entry>();
            foreach (EntryModel entry in entriesModels)
            {
                result.Add(entry.FromCommModel());
            }

            return result;
        }

        public static Order FromCommModel(this OrderModel orderModel)
        {
            Enum.TryParse(orderModel.Status, out Status status);
            return new Order
                (
                    orderModel.Id,
                    orderModel.ClientInfo.FromCommModel(),
                    orderModel.Entries.FromCommModel(),
                    status,
                    new DateTime(orderModel.AcceptanceDate),
                    new DateTime(orderModel.DeliveringDate)
                );
        }

        public static CustomerModel ToCommModel(this Customer customer)
        {
            return new CustomerModel
                (
                    customer.Id,
                    customer.Name,
                    customer.Address,
                    customer.PhoneNumber,
                    customer.Nip,
                    customer.Pesel
                );
        }

        public static MerchandiseModel ToCommModel(this Merchandise merchandise)
        {
            return new MerchandiseModel
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

        public static List<MerchandiseModel> ToCommModel(this List<Merchandise> merchandises)
        {
            List<MerchandiseModel> result = new List<MerchandiseModel>();
            foreach (Merchandise merchandise in merchandises)
            {
                result.Add(merchandise.ToCommModel());
            }

            return result;
        }

        public static EntryModel ToCommModel(this Entry entry)
        {
            return new EntryModel
                (
                    entry.Id,
                    entry.Merchandise.ToCommModel(),
                    entry.Amount,
                    entry.BruttoPrice
                );
        }

        public static List<EntryModel> ToCommModel(this List<Entry> entries)
        {
            List<EntryModel> result = new List<EntryModel>();
            foreach (Entry entry in entries)
            {
                result.Add(entry.ToCommModel());
            }

            return result;
        }

        public static OrderModel ToCommModel(this Order order)
        {
            return new OrderModel
                (
                    order.Id,
                    order.Client.ToCommModel(),
                    order.Entries.ToCommModel(),
                    order.Status.ToString(),
                    order.AcceptanceDate.Ticks,
                    order.DeliveringDate.Ticks
                );
        }
    }
}
