using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class DailyStats
    {
        private int _ordersAmount;
        private double _cheapestOrderPrice;
        private double _mostExpensiveOrderPrice;

        public int OrdersAmount { get => _ordersAmount; set => _ordersAmount = value; }
        public double CheapestOrderPrice { get => _cheapestOrderPrice; set => _cheapestOrderPrice = value; }
        public double MostExpensiveOrderPrice { get => _mostExpensiveOrderPrice; set => _mostExpensiveOrderPrice = value; }

        public DailyStats(int ordersAmount, double cheapestOrderPrice, double mostExpensiveOrderPrice)
        {
            _ordersAmount = ordersAmount;
            _cheapestOrderPrice = cheapestOrderPrice;
            _mostExpensiveOrderPrice = mostExpensiveOrderPrice;
        }
    }
}
