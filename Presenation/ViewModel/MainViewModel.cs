﻿using Logic;
using Logic.Dto;
using Logic.Events;
using Logic.Requests;
using Logic.Services;
using Presenation;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Presenation.Model;
using Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;

namespace Presenation.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        private Product _currentBasketProduct;
        private Entry _currentBasketEntry;
        private Entry _currentSearchEntry;
        private Customer _currentSearchCustomer;
        private OrderSummary _currentSearchOrderSummary;
        private string _searchOrderCode;
        private double _totalBruttoPrice;
        private string _customerId;
        private string _customerName;
        private string _customerAddress;
        private string _customerPhone;
        private string _customerNip;
        private string _customerPesel;
        private ObservableCollection<Product> _productsForBasket;
        private ObservableCollection<Entry> _basketEntries;
        private ObservableCollection<Entry> _searchEntries;
        private ObservableCollection<Customer> _searchCustomers;
        private ObservableCollection<OrderSummary> _searchOrders;
        private WebSocketClient _webSocketClient;

        private CyclicDiscountService _cyclicActionService;
        private IObservable<EventPattern<DiscountEvent>> _tickObservable;
        private IDisposable _observer;

        public Product CurrentBasketProduct 
        { 
            get => _currentBasketProduct; 
            set
            {
                _currentBasketProduct = value;
                RaisePropertyChanged();
            }
        
        }

        public Entry CurrentBasketEntry 
        { 
            get => _currentBasketEntry; 
            set
            {
                _currentBasketEntry = value;
                RaisePropertyChanged();
            }
        }

        public Entry CurrentSearchEntry
        {
            get => _currentSearchEntry;
            set
            {
                _currentSearchEntry = value;
                RaisePropertyChanged();
            }
        }

        public Customer CurrentSearchCustomer 
        { 
            get => _currentSearchCustomer; 
            set
            {
                _currentSearchCustomer = value;
                RaisePropertyChanged();
            }
        }

        public string SearchOrderCode
        {
            get => _searchOrderCode;
            set
            {
                _searchOrderCode = value;
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

        public OrderSummary CurrentSearchOrderSummary 
        { 
            get => _currentSearchOrderSummary; 
            set
            {
                _currentSearchOrderSummary = value;
                RaisePropertyChanged();
            }
        }
        
        public ObservableCollection<Product> ProductsForBasket 
        { 
            get => _productsForBasket; 
            set
            {
                _productsForBasket = value;
                RaisePropertyChanged();
            }
        }
        
        public ObservableCollection<Entry> BasketEntries 
        {
            get => _basketEntries; 
            set
            {
                _basketEntries = value;
                RaisePropertyChanged();
            }
        }
        
        public ObservableCollection<Entry> SearchEntries 
        { 
            get => _searchEntries; 
            set
            {
                _searchEntries = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Customer> SearchCustomers
        {
            get => _searchCustomers;
            set
            {
                _searchCustomers = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<OrderSummary> SearchOrders
        {
            get => _searchOrders;
            set
            {
                _searchOrders = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            _currentBasketProduct = null;
            _currentBasketEntry = null;
            _currentSearchCustomer = null;
            _currentSearchOrderSummary = null;
            _productsForBasket = new ObservableCollection<Product>();
            _basketEntries = new ObservableCollection<Entry>();
            AddProductToBasketCommand = new RelayCommand(AddProductToBasket);
            RemoveProductFromBasketCommand = new RelayCommand(RemoveProductFromBasket);
            ClearBasketCommand = new RelayCommand(ClearBasket);
            ConfirmBasketCommand = new RelayCommand(ConfirmBasket);
            SearchCustomerCommand = new RelayCommand(SearchCustomer);
            SearchOrderCommand = new RelayCommand(SearchOrder);

            _webSocketClient = new WebSocketClient();
            _webSocketClient.OnMessage.Subscribe(ReceiveMessage);
            _webSocketClient.Connect("ws://localhost/sklep/");
            _webSocketClient.GetMerchandisesRequest();
        }

        public void ReceiveMessage(string message)
        {
            WebMessageBase request = JsonConvert.DeserializeObject<WebMessageBase>(message);
            Console.WriteLine("[{0}] Client received response: {1} , status: {2}", DateTime.Now.ToString("HH:mm:ss.fff"), request.Tag, request.Status);
            string outp = String.Empty;

            if (request.Status == RequestStatus.FAIL)
            {
                MessageBox.Show(request.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            switch (request.Tag)
            {
                case "get_customer":
                    {
                        GetCustomerResponse response = response = JsonConvert.DeserializeObject<GetCustomerResponse>(message);
                        CustomerDto customerDto = response.Customer;
                        Customer customer = customerDto.FromDto();
                        CustomerId = customer.Id;
                        CustomerName = customer.Name;
                        CustomerAddress = customer.Address;
                        CustomerPhone = customer.ToString();
                        CustomerNip = customer.Nip;
                        CustomerPesel = customer.Pesel;
                        MessageBox.Show("Loaded customer info", "Response", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    }
                case "get_merchandises":
                    {
                        GetMerchandisesResponse response = JsonConvert.DeserializeObject<GetMerchandisesResponse>(message);
                        List<MerchandiseDto> merchandisesDto = response.Merchandises;
                        List<Product> products = merchandisesDto.FromDto();
                        _productsForBasket.Clear();
                        foreach (Product product in products)
                        {
                            _productsForBasket.Add(product);
                        }
                        _productsForBasket = new ObservableCollection<Product>(products);
                        MessageBox.Show("Loaded product", "Response", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    }
                    
                case "get_order":
                    MessageBox.Show("Get order message", "Response", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case "make_order":
                    MessageBox.Show("Make order", "Response", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }

        public RelayCommand AddProductToBasketCommand
        {
            get; private set;
        }

        public RelayCommand RemoveProductFromBasketCommand
        {
            get; private set;
        }

        public RelayCommand ClearBasketCommand
        {
            get; private set;
        }

        public RelayCommand ConfirmBasketCommand
        {
            get; private set;
        }

        public RelayCommand SearchOrderCommand
        {
            get; private set;
        }

        public RelayCommand SearchCustomerCommand
        {
            get; private set;
        }

        public RelayCommand ConfirmCommand
        {
            get; private set;
        }

        public void AddProductToBasket()
        {
            if (_currentBasketProduct != null)
            {
                List<Entry> entries = _basketEntries.ToList();
                Entry foundEntry = entries.Where(item => item.Code == _currentBasketProduct.Id).FirstOrDefault();
                string input = Interaction.InputBox("Enter product amount", "Amount", "");
                if (!int.TryParse(input, out int amountNum) )
                {
                    ShowErrorPopupWindow("Amount cannot be empty");
                }
                else
                {
                int entryNum = 1;
                if (entries.Count!=0)
                    entryNum = entries.Max(entry => entry.Id) + 1;

                    if (foundEntry == null)
                    {  
                        double netto = _currentBasketProduct.NettoPrice;
                        double vat = _currentBasketProduct.Vat;
                        double brutto = CalcHelper.GetBruttoPrice(netto, vat);
                        double totalBrutto = CalcHelper.GetTotalBrutto(brutto, amountNum);
                        Entry newEntry = new Entry
                        (
                            entryNum,
                            _currentBasketProduct.Id,
                            _currentBasketProduct.Name,
                            _currentBasketProduct.Description,
                            _currentBasketProduct.Type,
                            _currentBasketProduct.Unit,
                            netto,
                            vat,
                            amountNum,
                            brutto,
                            totalBrutto
                        );
                        _basketEntries.Add(newEntry);
                    }
                    else
                    {
                        int index = _basketEntries.IndexOf(foundEntry);
                        Debug.WriteLine(index);
                        foundEntry.Amount += amountNum;
                        _basketEntries[index].Amount += amountNum;
                    }
                }
            }
        }
        
        public void RemoveProductFromBasket()
        {
            if (_currentBasketEntry != null && _basketEntries.Contains(_currentBasketEntry))
            {
                _basketEntries.Remove(_currentBasketEntry);
            }
        }

        public void ClearBasket()
        {
            _basketEntries.Clear();
        }

        public void ConfirmBasket()
        {
            int.TryParse(_customerPhone, out int phone);
            Customer customer = new Customer(_customerId, _customerName, _customerAddress, phone, _customerNip, _customerPesel);
            List<Entry> basketEntries = _basketEntries.ToList();
            List<EntryDto> basketEntriesDto = basketEntries.ToDto();
            OrderSummary orderSummary = new OrderSummary();
            orderSummary.TotalBrutto = CalcHelper.GetTotalBrutto(basketEntriesDto);
            OrderDto orderDto = orderSummary.ToDto(customer, basketEntries);
            //_orderService.SaveOrder(orderDto);
            _webSocketClient.MakeOrderRequest(orderDto);
        }

        public void SearchCustomer()
        {
            if (!string.IsNullOrEmpty(_customerId) && !string.IsNullOrWhiteSpace(_customerId))
            {
                _webSocketClient.GetCustomerRequest(_customerId);
            }
        }

        public void SearchOrder()
        {
            try
            {
                if(!string.IsNullOrEmpty(_searchOrderCode) && !string.IsNullOrWhiteSpace(_searchOrderCode))
                {

                }
               // OrderDto orderDto = _orderService.GetOrder(_searchOrderCode);
                //OrderSummary orderSummary = orderDto.FromDto();
                //Customer customer = orderDto.ClientInfo.FromDto();
                //List<Entry> entries = orderDto.Entries.FromDto();
                //_searchCustomers.Clear();
                //_searchOrders.Clear();
                //_searchEntries.Clear();
                //_searchCustomers.Add(customer);
                //_searchOrders.Add(orderSummary);
                //foreach (Entry entry in entries)
                //{
                //    _searchEntries.Add(entry);
                //}
            }
            catch(Exception e)
            {
                ShowErrorPopupWindow(e.Message);
            }
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
