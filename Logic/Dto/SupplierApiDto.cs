using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Dto
{
    public class SupplierApiDto
    {
        private string _name;
        private string _address;
        private string _nip;

        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public string Nip { get => _nip; set => _nip = value; }

        public SupplierApiDto(string name, string address, string nip)
        {
            _name = name;
            _address = address;
            _nip = nip;
        }
    }
}
