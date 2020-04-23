using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dto
{
    public class ClientApiDto
    {
        private string _name;
        private string _address;
        private int _phoneNumber;
        private string _nip;
        private string _pesel;

        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public int PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Nip { get => _nip; set => _nip = value; }
        public string Pesel { get => _pesel; set => _pesel = value; }

        public ClientApiDto(string name, string address, int phoneNumber, string nip, string pesel)
        {
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
            _nip = nip;
            _pesel = pesel;
        }
    }
}
