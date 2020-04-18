using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Dto
{
    public class OrderApiDto
    {
        private string _code;
        private ClientApiDto _clientInfo;
        private List<EntryApiDto> _entries;
        private string _status;
        private double _totalBruttoPrice;
        private long _acceptanceDate;
        private long _sendingDate;
        private long _deliveringDate;

        public string Code { get => _code; set => _code = value; }
        public ClientApiDto ClientInfo { get => _clientInfo; set => _clientInfo = value; }
        public List<EntryApiDto> Entries { get => _entries; set => _entries = value; }
        public string Status { get => _status; set => _status = value; }
        public double TotalBruttoPrice { get => _totalBruttoPrice; set => _totalBruttoPrice = value; }
        public long AcceptanceDate { get => _acceptanceDate; set => _acceptanceDate = value; }
        public long SendingDate { get => _sendingDate; set => _sendingDate = value; }
        public long DeliveringDate { get => _deliveringDate; set => _deliveringDate = value; }

        public OrderApiDto(string code, ClientApiDto clientInfo, List<EntryApiDto> entries, string status, double totalBruttoPrice, long acceptanceDate, long sendingDate, long deliveringDate)
        {
            _code = code;
            _clientInfo = clientInfo;
            _entries = entries;
            _status = status;
            _totalBruttoPrice = totalBruttoPrice;
            _acceptanceDate = acceptanceDate;
            _sendingDate = sendingDate;
            _deliveringDate = deliveringDate;
        }
    }
}
