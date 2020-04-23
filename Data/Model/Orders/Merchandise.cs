using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Merchandise
    {
        private int _id;
        private string _name;
        private string  _description;
        private ArticleType _type;
        private ArticleUnit _unit;
        private double _nettoPrice;
        private double _vat;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public double NettoPrice { get => _nettoPrice; set => _nettoPrice = value; }
        public double Vat { get => _vat; set => _vat = value; }
        public ArticleType Type { get => _type; set => _type = value; }
        public ArticleUnit Unit { get => _unit; set => _unit = value; }

        public Merchandise()
        {
        }

        public Merchandise(string name, string description, ArticleType type, ArticleUnit unit, double nettoPrice, double vat)
        {
            _name = name;
            _description = description;
            _type = type;
            _unit = unit;
            _nettoPrice = nettoPrice;
            _vat = vat;
        }

        public Merchandise(int id, string name, string description, ArticleType type, ArticleUnit unit, double nettoPrice, double vat)
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
