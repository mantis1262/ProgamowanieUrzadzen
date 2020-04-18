using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model.Contact
{
    public class Supplier : ContactInfo
    {
        public Supplier()
        {
        }

        public Supplier(string name, string address, int phoneNumber) : base(name, address, phoneNumber)
        {
        }

        public Supplier(int id, string name, string address, int phoneNumber, string nip) : base(id, name, address, phoneNumber)
        {
            Nip = nip;
        }
    }
}
