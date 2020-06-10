using System;
using System.Collections.Generic;
using System.Text;

namespace Communication.Model
{
    public class DiscountData
    {
        public DateTime Time { get; set; }

        public double Discount { get; private set; }

        public List<MerchandiseModel> Merchandises { get; private set; }

        public DiscountData(double discount, List<MerchandiseModel> merchandises)
        {
            Time = DateTime.Now;
            Discount = discount;
            Merchandises = merchandises;
        }
    }
}
