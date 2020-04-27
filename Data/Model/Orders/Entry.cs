﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Entry
    {
        private int _id;
        private Merchandise _merchandise;
        private int _amount;
        private double _bruttoPrice;

        public int Id { get => _id; set => _id = value; }
        public Merchandise Merchandise { get => _merchandise; set => _merchandise = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public double BruttoPrice { get => _bruttoPrice; set => _bruttoPrice = value; }

        public Entry()
        {
        }

        public Entry(int id, Merchandise merchandise, int amount, double bruttoPrice)
        {
            _id = id;
            _merchandise = merchandise;
            _amount = amount;
            _bruttoPrice = bruttoPrice;
        }
    }
}
