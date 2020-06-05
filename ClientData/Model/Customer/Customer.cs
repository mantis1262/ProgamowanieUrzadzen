using System;
using System.Collections.Generic;
using System.Text;

namespace ClientData.Model
{
    public class Customer
    {
        private string _id;
        private string _name;
        private string _address;
        private int _phoneNumber;
        private string _nip;
        private string _pesel;

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public int PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Nip { get => _nip; set => _nip = value; }
        public string Pesel { get => _pesel; set => _pesel = value; }

        public Customer()
        {
        }

        public Customer(string id, string name, string address, int phoneNumber, string nip, string pesel)
        {
            _id = id;
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
            _nip = nip;
            _pesel = pesel;
        }

        public override bool Equals(object obj)
        {
            return obj is Customer client &&
                   _id == client._id &&
                   _name == client._name &&
                   _phoneNumber == client._phoneNumber;
        }

        public override int GetHashCode()
        {
            int hashCode = 1164615363;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + _phoneNumber.GetHashCode();
            return hashCode;
        }
    }
}
