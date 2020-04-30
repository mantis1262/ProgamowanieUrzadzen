using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Dto
{
    public class OrderDto
    {
        private string _id;
        private ClientDto _clientInfo;
        private List<EntryDto> _entries;
        private string _status;
        private double _totalBruttoPrice;
        private long _acceptanceDate;
        private long _deliveringDate;

        public OrderDto(string id, ClientDto clientInfo, List<EntryDto> entries, string status, double totalBruttoPrice, long acceptanceDate, long deliveringDate)
        {
            _id = id;
            _clientInfo = clientInfo;
            _entries = entries;
            _status = status;
            _totalBruttoPrice = totalBruttoPrice;
            _acceptanceDate = acceptanceDate;
            _deliveringDate = deliveringDate;
        }

        public string Id { get => _id; set => _id = value; }
        public ClientDto ClientInfo { get => _clientInfo; set => _clientInfo = value; }
        public List<EntryDto> Entries { get => _entries; set => _entries = value; }
        public string Status { get => _status; set => _status = value; }
        public double TotalBruttoPrice { get => _totalBruttoPrice; set => _totalBruttoPrice = value; }
        public long AcceptanceDate { get => _acceptanceDate; set => _acceptanceDate = value; }
        public long DeliveringDate { get => _deliveringDate; set => _deliveringDate = value; }

        
    }
}
