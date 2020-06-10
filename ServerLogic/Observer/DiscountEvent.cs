using ServerLogic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogic.Observer
{
    public class DiscountEvent : EventArgs
    {
        public DateTime Time { get; set; }

        public double Discount { get; private set; }

        public List<MerchandiseDto> Merchandises { get; private set; }

        public DiscountEvent(double discount, List<MerchandiseDto> merchandises)
        {
            Time = DateTime.Now;
            Discount = discount;
            Merchandises = merchandises;
        }
    }
}
