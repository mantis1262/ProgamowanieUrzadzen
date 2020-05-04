using Logic.Dto;
using Logic.Services;
using Presenation.Model;
using Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Presenation.ViewModel
{
    internal class CustomerInfoViewModel : ViewModelBase
    {
        private List<Entry> _entries;
        private OrderSummary _orderSummary;
        private string _customerId;
        private string _customerName;
        private string _customerAddress;
        private string _customerPhone;
        private string _customerNip;
        private string _customerPesel;
        private OrderService _orderService;

        public List<Entry> Entries
        {
            get => _entries;
            set
            {
                _entries = value;
                RaisePropertyChanged();
            }
        }

        public OrderSummary OrderSummary
        {
            get => _orderSummary;
            set
            {
                _orderSummary = value;
                RaisePropertyChanged();
            }
        }

        public string CustomerId 
        { 
            get => _customerId; 
            set
            {
                _customerId = value;
                RaisePropertyChanged();
            }
        }

        public string CustomerName 
        { 
            get => _customerName; 
            set
            {
                _customerName = value;
                RaisePropertyChanged();
            }
        }

        public string CustomerAddress 
        { 
            get => _customerAddress; 
            set
            {
                _customerAddress = value;
                RaisePropertyChanged();
            }
        }

        public string CustomerPhone 
        { 
            get => _customerPhone; 
            set
            {
                _customerPhone = value;
                RaisePropertyChanged();
            }
        }

        public string CustomerNip 
        { 
            get => _customerNip; 
            set
            {
                _customerNip = value;
                RaisePropertyChanged();
            }
        }

        public string CustomerPesel 
        { 
            get => _customerPesel; 
            set
            {
                _customerPesel = value;
                RaisePropertyChanged();
            }
        }

        public OrderService OrderService 
        { 
            get => _orderService; 
            set => _orderService = value; 
        }


        public CustomerInfoViewModel()
        {
            _entries = new List<Entry>();
            SearchCommand = new RelayCommand(SearchCustomer);
            ConfirmCommand = new RelayCommand(ConfirmOrder);
        }

        public RelayCommand SearchCommand
        {
            get; private set;
        }

        public RelayCommand ConfirmCommand
        {
            get; private set;
        }

        public void SearchCustomer()
        {
            try
            {
                Customer customer = _orderService.CustomerService.GetCustomer(_customerId).FromDto();
                _customerName = customer.Name;
                _customerAddress = customer.Address;
                _customerPhone = customer.ToString();
                _customerNip = customer.Nip;
                _customerPesel = customer.Pesel;
            }
            catch (Exception e)
            {
                ShowErrorPopupWindow(e.Message);
            }
            
        }

        public void ConfirmOrder()
        {
            int.TryParse(_customerPhone, out int phone);
            Customer customer = new Customer("", _customerName, _customerAddress, phone, _customerNip, _customerPesel);
            OrderDto orderDto = _orderSummary.ToDto(customer, _entries);
            _orderService.SaveOrder(orderDto);
        }

        internal Func<string, string, MessageBoxButton, MessageBoxImage, MessageBoxResult> MessageBoxShowDelegate { get; set; } = MessageBox.Show;

        private void ShowErrorPopupWindow(string mesg)
        {
            MessageBoxShowDelegate(mesg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ShowInfoPopupWindow(string mesg)
        {
            MessageBoxShowDelegate(mesg, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
