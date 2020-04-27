using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Dto
{
    public class ClientDto
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

        public ClientDto(string id, string name, string address, int phoneNumber, string nip, string pesel)
        {
            _id = id;
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
            _nip = nip;
            _pesel = pesel;
        }
    }
}
