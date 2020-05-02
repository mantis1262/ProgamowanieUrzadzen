using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
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
    }
}
