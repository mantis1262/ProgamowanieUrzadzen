using System;
using System.Collections.Generic;
using System.Text;

namespace Communication.Model
{
    public class OrderModel
    {
        private string _id;
        private CustomerModel _clientInfo;
        private List<EntryModel> _entries;
        private string _status;
        private long _acceptanceDate;
        private long _deliveringDate;

        public OrderModel()
        {

        }

        public OrderModel(string id, CustomerModel clientInfo, List<EntryModel> entries, string status, long acceptanceDate, long deliveringDate)
        {
            _id = id;
            _clientInfo = clientInfo;
            _entries = entries;
            _status = status;
            _acceptanceDate = acceptanceDate;
            _deliveringDate = deliveringDate;
        }

        public OrderModel(CustomerModel clientInfo, List<EntryModel> entries, string status, double totalBruttoPrice, long acceptanceDate, long deliveringDate)
        {
            _clientInfo = clientInfo;
            _entries = entries;
            _status = status;
            _acceptanceDate = acceptanceDate;
            _deliveringDate = deliveringDate;
        }

        public string Id { get => _id; set => _id = value; }
        public CustomerModel ClientInfo { get => _clientInfo; set => _clientInfo = value; }
        public List<EntryModel> Entries { get => _entries; set => _entries = value; }
        public string Status { get => _status; set => _status = value; }
        public long AcceptanceDate { get => _acceptanceDate; set => _acceptanceDate = value; }
        public long DeliveringDate { get => _deliveringDate; set => _deliveringDate = value; }

        
    }
}
