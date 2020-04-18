using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model.Contact
{
    public class ContactInfo
    {
        private int _id;
        private string _name;
        private string _address;
        private int _phoneNumber;
        private string _nip;

        public ContactInfo()
        {
        }

        public ContactInfo(string name, string address, int phoneNumber)
        {
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
        }

        public ContactInfo(int id, string name, string address, int phoneNumber)
        {
            _id = id;
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public int PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Nip { get => _nip; set => _nip = value; }
    }
}
