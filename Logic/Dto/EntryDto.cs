using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Dto
{
    public class EntryDto
    {
        private int _id;
        private MerchandiseDto _merchandise;
        private int _amount;
        private double _bruttoPrice;
        private double _totalBruttoPrice;

        public int Id { get => _id; set => _id = value; }
        public MerchandiseDto Merchandise { get => _merchandise; set => _merchandise = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public double BruttoPrice { get => _bruttoPrice; set => _bruttoPrice = value; }
        public double TotalBruttoPrice { get => _totalBruttoPrice; set => _totalBruttoPrice = value; }

        public EntryDto(int id, MerchandiseDto merchandise, int amount, double bruttoPrice, double totalBruttoPrice)
        {
            _id = id;
            _merchandise = merchandise;
            _amount = amount;
            _bruttoPrice = bruttoPrice;
            _totalBruttoPrice = totalBruttoPrice;
        }
    }
}
