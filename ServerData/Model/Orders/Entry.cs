using System;
using System.Collections.Generic;
using System.Text;

namespace ServerData.Model
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

        public override bool Equals(object obj)
        {
            return obj is Entry entry &&
                   _id == entry._id &&
                   EqualityComparer<Merchandise>.Default.Equals(_merchandise, entry._merchandise);
        }

        public override int GetHashCode()
        {
            int hashCode = -1317184676;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Merchandise>.Default.GetHashCode(_merchandise);
            return hashCode;
        }
    }
}
