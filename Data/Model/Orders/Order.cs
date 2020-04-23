using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Order
    {
        private string _id;
        private string _code;
        private ClientContactInfo _client;
        private List<Entry> _entries;
        private Status _status;
        private DateTime _acceptanceDate;
        private DateTime _sendingDate;
        private DateTime _deliveringDate;

        public string Id { get => _id; set => _id = value; }
        public string Code { get => _code; set => _code = value; }
        public ClientContactInfo Client { get => _client; set => _client = value; }
        public List<Entry> Entries { get => _entries; set => _entries = value; }
        public Status Status { get => _status; set => _status = value; }
        public DateTime AcceptanceDate { get => _acceptanceDate; set => _acceptanceDate = value; }
        public DateTime SendingDate { get => _sendingDate; set => _sendingDate = value; }
        public DateTime DeliveringDate { get => _deliveringDate; set => _deliveringDate = value; }

        public Order()
        {
        }

        public Order(string code, ClientContactInfo client, List<Entry> entries, Status status, DateTime acceptanceDate, DateTime sendingDate, DateTime deliveringDate)
        {
            _code = code;
            _client = client;
            _entries = entries;
            _status = status;
            _acceptanceDate = acceptanceDate;
            _sendingDate = sendingDate;
            _deliveringDate = deliveringDate;
        }

        public Order(string id, string code, ClientContactInfo client, List<Entry> entries, Status status, DateTime acceptanceDate, DateTime sendingDate, DateTime deliveringDate)
        {
            _id = id;
            _code = code;
            _client = client;
            _entries = entries;
            _status = status;
            _acceptanceDate = acceptanceDate;
            _sendingDate = sendingDate;
            _deliveringDate = deliveringDate;
        }
    }
}
