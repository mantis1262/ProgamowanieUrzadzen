using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Order
    {
        private string _id;
        private ClientContactInfo _client;
        private List<Entry> _entries;
        private Status _status;
        private DateTime _acceptanceDate;
        private DateTime _deliveringDate;

        public string Id { get => _id; set => _id = value; }
        public ClientContactInfo Client { get => _client; set => _client = value; }
        public List<Entry> Entries { get => _entries; set => _entries = value; }
        public Status Status { get => _status; set => _status = value; }
        public DateTime AcceptanceDate { get => _acceptanceDate; set => _acceptanceDate = value; }
        public DateTime DeliveringDate { get => _deliveringDate; set => _deliveringDate = value; }

        public Order()
        {
        }

        public Order(string id, ClientContactInfo client, List<Entry> entries, Status status, DateTime acceptanceDate, DateTime deliveringDate)
        {
            _id = id;
            _client = client;
            _entries = entries;
            _status = status;
            _acceptanceDate = acceptanceDate;
            _deliveringDate = deliveringDate;
        }
    }
}
