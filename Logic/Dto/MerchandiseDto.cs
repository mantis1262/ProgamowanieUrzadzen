using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Dto
{
    public class MerchandiseDto
    {
        private string _id;
        private string _name;
        private string _description;
        private string _type;
        private string _unit;
        private double _nettoPrice;
        private double _vat;

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string Type { get => _type; set => _type = value; }
        public string Unit { get => _unit; set => _unit = value; }
        public double NettoPrice { get => _nettoPrice; set => _nettoPrice = value; }
        public double Vat { get => _vat; set => _vat = value; }

        public MerchandiseDto(string id, string name, string description, string type, string unit, double nettoPrice, double vat)
        {
            _id = id;
            _name = name;
            _description = description;
            _type = type;
            _unit = unit;
            _nettoPrice = nettoPrice;
            _vat = vat;
        }
    }
}
