using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model.Contact
{
    public class Client : ContactInfo
    {
        private string _pesel;

        public string Pesel { get => _pesel; set => _pesel = value; }

        public Client()
        {
        }

        public Client(string name, string address, int phoneNumber) : base(name, address, phoneNumber)
        {
        }

        public Client(string name, string address, int phoneNumber, string nip, string pesel) : base(name, address, phoneNumber)
        {
            Nip = nip;
            _pesel = pesel;
        }

        public Client(int id, string name, string address, int phoneNumber) : base(id, name, address, phoneNumber)
        {
        }

        public Client(int id, string name, string address, int phoneNumber, string nip, string pesel) : base(id, name, address, phoneNumber)
        {
            Nip = nip;
            _pesel = pesel;
        }
    }
}
