using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPresentation.Model
{
    public class Entry
    {
        private int _id;
        private string _code;
        private string _name;
        private string _description;
        private string _type;
        private string _unit;
        private double _nettoPrice;
        private double _vat;
        private int _amount;
        private double _bruttoPrice;
        private double _totalBruttoPrice;

        public int Id { get => _id; set => _id = value; }
        public string Code { get => _code; set => _code = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string Type { get => _type; set => _type = value; }
        public string Unit { get => _unit; set => _unit = value; }
        public double NettoPrice { get => _nettoPrice; set => _nettoPrice = value; }
        public double Vat { get => _vat; set => _vat = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public double BruttoPrice { get => _bruttoPrice; set => _bruttoPrice = value; }
        public double TotalBruttoPrice { get => _totalBruttoPrice; set => _totalBruttoPrice = value; }

        public Entry()
        {
        }

        public Entry(int id, string code, string name, string description, string type, string unit, double nettoPrice, double vat, int amount, double bruttoPrice, double totalBruttoPrice)
        {
            _id = id;
            _code = code;
            _name = name;
            _description = description;
            _type = type;
            _unit = unit;
            _nettoPrice = nettoPrice;
            _vat = vat;
            _amount = amount;
            _bruttoPrice = bruttoPrice;
            _totalBruttoPrice = totalBruttoPrice;
        }
    }
}
