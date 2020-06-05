using ClientLogic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientLogic
{
    public static class CalcHelper
    {
        public static double GetBruttoPrice(double nettoPrice, double vat)
        {
            return nettoPrice + nettoPrice * vat;
        }

        public static double GetTotalBrutto(double bruttoPrice, int amount)
        {
            return bruttoPrice * amount;
        }

        public static double GetTotalBrutto(List<EntryDto> entries)
        {
            double sum = 0;

            foreach(EntryDto entry in entries)
            {
                sum += GetTotalBrutto(entry.BruttoPrice, entry.Amount);
            }

            return sum;
        }
    }
}
