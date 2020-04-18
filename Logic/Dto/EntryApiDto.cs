using Data.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Dto
{
    public class EntryApiDto
    {
        private int _number;
        private string _name;
        private string _description;
        private string _type;
        private string _unit;
        private string _supplier;
        private int _amount;
        private double _bruttoPrice;
        private double _totalBruttoPrice;

        public int Number { get => _number; set => _number = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string Type { get => _type; set => _type = value; }
        public string Unit { get => _unit; set => _unit = value; }
        public string Supplier { get => _supplier; set => _supplier = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public double BruttoPrice { get => _bruttoPrice; set => _bruttoPrice = value; }
        public double TotalBruttoPrice { get => _totalBruttoPrice; set => _totalBruttoPrice = value; }

        public EntryApiDto()
        {

        }

        public EntryApiDto(int number, string name, string description, string type, string unit, string supplier, int amount, double bruttoPrice, double totalBruttoPrice)
        {
            _number = number;
            _name = name;
            _description = description;
            _type = type;
            _unit = unit;
            _supplier = supplier;
            _amount = amount;
            _bruttoPrice = bruttoPrice;
            _totalBruttoPrice = totalBruttoPrice;
        }
    }
}
