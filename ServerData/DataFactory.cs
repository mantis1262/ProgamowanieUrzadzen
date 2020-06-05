using ServerData.Interfaces;
using ServerData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerData
{
    public class DataFactory : IDataFiller
    {
        public void Fill(DataContext dataContext)
        {
            Customer customer1 = new Customer("CLIENT_1", "Adam Lewandowski", "ul. Wesoła 5/3, Lipno", 648229110, "", "93819284050");

            Merchandise merchandise1 = new Merchandise("93810", "Lodówka Max", "Najnowszy model lodówki", ArticleType.AGD, ArticleUnit.PIECE, 749.99, 0.23);
            Merchandise merchandise2 = new Merchandise("5326", "Mydło w płynie", "Mydło w płynie o zapachu lawendy", ArticleType.CHEMICALS, ArticleUnit.PACK, 20.49, 0.15);
            Merchandise merchandise3 = new Merchandise("2251", "Pomidory luz", "Polskie pomidory z pola", ArticleType.GROCERIES, ArticleUnit.KILOS, 5.99, 0.10);

            //Entry entry1 = new Entry(1, merchandise1, 1, 922.49);
            //Entry entry2 = new Entry(2, merchandise2, 2, 23.56);
            //Entry entry3 = new Entry(3, merchandise3, 7, 6.59);
            //List<Entry> entries = new List<Entry>();
            //entries.Add(entry1);
            //entries.Add(entry2);
            //entries.Add(entry3);

            //Order order1 = new Order("ORDER_1", customer1, entries, Status.IN_PROGRESS, DateTime.Now, DateTime.Now.AddDays(4));

            dataContext.Customers.Add(customer1.Id, customer1);
            dataContext.Merchandises.Add(merchandise1.Id, merchandise1);
            dataContext.Merchandises.Add(merchandise2.Id, merchandise2);
            dataContext.Merchandises.Add(merchandise3.Id, merchandise3);
            //dataContext.Orders.Add(order1.Id, order1);
        }
    }
}
