using System;
using System.Collections.Generic;
using System.Text;

namespace Communication.Model
{
    public class EntryModel
    {
        private int _id;
        private MerchandiseModel _merchandise;
        private int _amount;
        private double _bruttoPrice;

        public int Id { get => _id; set => _id = value; }
        public MerchandiseModel Merchandise { get => _merchandise; set => _merchandise = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public double BruttoPrice { get => _bruttoPrice; set => _bruttoPrice = value; }

        public EntryModel()
        {

        }

        public EntryModel(int id, MerchandiseModel merchandise, int amount, double bruttoPrice)
        {
            _id = id;
            _merchandise = merchandise;
            _amount = amount;
            _bruttoPrice = bruttoPrice;
        }
    }
}
