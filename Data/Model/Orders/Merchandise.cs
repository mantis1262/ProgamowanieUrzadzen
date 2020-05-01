using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Merchandise
    {
        private string _id;
        private string _name;
        private string  _description;
        private ArticleType _type;
        private ArticleUnit _unit;
        private double _nettoPrice;
        private double _vat;

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public ArticleType Type { get => _type; set => _type = value; }
        public ArticleUnit Unit { get => _unit; set => _unit = value; }
        public double NettoPrice { get => _nettoPrice; set => _nettoPrice = value; }
        public double Vat { get => _vat; set => _vat = value; }

        public Merchandise()
        {
        }

        public Merchandise(string id, string name, string description, ArticleType type, ArticleUnit unit, double nettoPrice, double vat)
        {
            _id = id;
            _name = name;
            _description = description;
            _type = type;
            _unit = unit;
            _nettoPrice = nettoPrice;
            _vat = vat;
        }

        public override bool Equals(object obj)
        {
            return obj is Merchandise merchandise &&
                   _id == merchandise._id &&
                   _name == merchandise._name;
        }

        public override int GetHashCode()
        {
            int hashCode = 321773176;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            return hashCode;
        }
    }
}
