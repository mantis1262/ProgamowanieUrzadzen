using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPresentation.Model
{
    public class OrderSummary
    {
        private string _id;
        private string _status;
        private double _totalBrutto;
        private DateTime _submittedDate;
        private DateTime _deliveredDate;

        public string Id { get => _id; set => _id = value; }
        public string Status { get => _status; set => _status = value; }
        public double TotalBrutto { get => _totalBrutto; set => _totalBrutto = value; }
        public DateTime SubmittedDate { get => _submittedDate; set => _submittedDate = value; }
        public DateTime DeliveredDate { get => _deliveredDate; set => _deliveredDate = value; }

        public OrderSummary()
        {
        }

        public OrderSummary(string id, string status, double totalBrutto, DateTime submittedDate, DateTime deliveredDate)
        {
            _id = id;
            _status = status;
            _totalBrutto = totalBrutto;
            _submittedDate = submittedDate;
            _deliveredDate = deliveredDate;
        }
    }
}
