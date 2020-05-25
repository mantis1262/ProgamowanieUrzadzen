using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Observer
{
    public class DiscountEvent : EventArgs
    {
        public DateTime Time { get; set; }

        public double Discount { get; private set; }

        public DiscountEvent(double discount)
        {
            Time = DateTime.Now;
            Discount = discount;
        }
    }
}
