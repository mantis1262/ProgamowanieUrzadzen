using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Helpers
{
    public static class OrderCalc
    {
        public static double CalculateTotalSingleBruttoPrice(int amount, double bruttoPrice)
        {
            return amount * bruttoPrice;
        }

        public static double CalculateTotalOrderButtoPrice(Order order)
        {
            double totalBruttoPrice = 0;

            foreach (Entry entry in order.Entries)
            {
                totalBruttoPrice += entry.BruttoPrice;
            }

            return totalBruttoPrice;
        }
    }
}
