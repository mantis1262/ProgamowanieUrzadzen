using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Entry
    {
        private int _id;
        private int _number;
        private Merchandise _merchandise;
        private int _amount;
        private double _bruttoPrice;

        public Entry()
        {
        }

        public Entry(int number, Merchandise merchandise, int amount, double bruttoPrice)
        {
            _number = number;
            _merchandise = merchandise;
            _amount = amount;
            _bruttoPrice = bruttoPrice;
        }

        public int Id { get => _id; set => _id = value; }
        public int Number { get => _number; set => _number = value; }
        public Merchandise Merchandise { get => _merchandise; set => _merchandise = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public double BruttoPrice { get => _bruttoPrice; set => _bruttoPrice = value; }
    }
}
