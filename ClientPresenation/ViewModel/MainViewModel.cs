﻿using ClientLogic;
using ClientLogic.Dto;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using ClientPresentation.Model;
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
using System.Security.Policy;
using ClientLogic.Services;

namespace ClientPresentation.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        #region Fields
        private Product _currentBasketProduct;
        private Entry _currentBasketEntry;
        private Entry _currentSearchEntry;
        private Customer _currentSearchCustomer;
        private OrderSummary _currentSearchOrderSummary;
        private string _searchOrderCode;
        private double _totalBruttoPrice = 0;
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
        private ManageDataService _manageDataService;
        private bool _subStatusBool;
        private string _subStatusLabel = "OFF";
        private string _uriPeer = "ws://localhost:8081/";
        #endregion

        #region Properties
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

        public double TotalBruttoPrice
        {
            get => _totalBruttoPrice;
            set
            {
                _totalBruttoPrice = value;
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

        public string SubStatus
        {
            get => _subStatusLabel;
            set
            {
                _subStatusLabel = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Commands
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

        public RelayCommand SubscriptionCommand
        {
            get; private set;
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            _currentBasketProduct = null;
            _currentBasketEntry = null;
            _currentSearchCustomer = null;
            _currentSearchOrderSummary = null;
            _productsForBasket = new ObservableCollection<Product>();
            _basketEntries = new ObservableCollection<Entry>();
            _searchCustomers = new ObservableCollection<Customer>();
            _searchOrders = new ObservableCollection<OrderSummary>();
            _searchEntries = new ObservableCollection<Entry>();
            AddProductToBasketCommand = new RelayCommand(AddProductToBasket);
            RemoveProductFromBasketCommand = new RelayCommand(RemoveProductFromBasket);
            ClearBasketCommand = new RelayCommand(ClearBasket);
            ConfirmBasketCommand = new RelayCommand(ConfirmBasket);
            SearchCustomerCommand = new RelayCommand(SearchCustomer);
            SearchOrderCommand = new RelayCommand(SearchOrder);
            SubscriptionCommand = new RelayCommand(SubscriptionStatusChange);

            _manageDataService = new ManageDataService(ProcessLog, _uriPeer);
            _manageDataService.messageChain.Subscribe(ReceiveMessage);
            Task.Factory.StartNew(async () => 
            {
                await _manageDataService.communicationService.CreateConnection();
                await _manageDataService.communicationService.AskForMerchandises();
            });
        }
        #endregion

        #region MessagesProcessing
        public void ReceiveMessage(string message)
        {
            try
            {
                Debug.WriteLine("[{0}] Client was informed about {1}", DateTime.Now.ToString("HH:mm:ss.fff"), message);
                string outp = String.Empty;

                if (message.StartsWith("ERROR:"))
                {
                    ProcessLog(message);
                    return;
                }

                switch (message)
                {
                    case "get_customer":
                        {
                            Task.Factory.StartNew(async () => await RefreshCustomerMesg());
                            break;
                        }
                    case "get_merchandises":
                        {
                            Task.Factory.StartNew(async () => await RefreshMerchandisesMesg());
                            break;
                        }
                    case "get_order":
                        {
                            Task.Factory.StartNew(async () => await RefreshOrderMesg());
                            break;
                        }
                    case "subscription":
                        {
                            Task.Factory.StartNew(() => SubscribeMesg());
                            break;
                        }
                    case "unsubscription":
                        {
                            Task.Factory.StartNew(() => UnsubscribeMesg());
                            break;
                        }
                }

                if (message.StartsWith("save_order"))
                {
                    Task.Factory.StartNew(() => SaveOrderMesg(message));
                }

                if (message.StartsWith("discount"))
                {
                    Task.Factory.StartNew(() => ProcessDiscountMessage(message));
                }
            }
            catch(Exception e)
            {
                ShowErrorPopupWindow("Error: " + e.Message);
            }
        }

        private async Task RefreshCustomerMesg()
        {
            CustomerDto customerDto = await _manageDataService.GetCurrentCustomer();
            Customer customer = customerDto.FromDto();
            CustomerId = customer.Id;
            CustomerName = customer.Name;
            CustomerAddress = customer.Address;
            CustomerPhone = customer.PhoneNumber.ToString();
            CustomerNip = customer.Nip;
            CustomerPesel = customer.Pesel;

            ShowInfoPopupWindow("Loaded customer info");
        }

        private async Task RefreshMerchandisesMesg()
        {
            IList<MerchandiseDto> merchandisesDto = await _manageDataService.GetMerchandises();
            List<Product> products = merchandisesDto.ToList().FromDto();
            ProductsForBasket.Clear();
            foreach (Product product in products)
            {
                ProductsForBasket.Add(product);
            }

            ShowInfoPopupWindow("Loaded product");
        }

        private async Task RefreshOrderMesg()
        {
            OrderDto orderDto = await _manageDataService.GetCurrentOrder();
            Customer customer = orderDto.ClientInfo.FromDto();
            OrderSummary orderSummary = orderDto.FromDto();
            List<Entry> entries = orderDto.Entries.FromDto();

            _searchCustomers.Clear();
            _searchOrders.Clear();
            _searchEntries.Clear();
            _searchCustomers.Add(customer);
            _searchOrders.Add(orderSummary);

            foreach (Entry entry in entries)
            {
                _searchEntries.Add(entry);
            }

            ShowInfoPopupWindow("Loaded order");
        }

        private void SaveOrderMesg(string message)
        {
            string[] parts = message.Split(':');
            string clientId = parts[1];
            string orderId = parts[2];
            CustomerId = clientId;
            _basketEntries.Clear();

            ShowInfoPopupWindow(clientId + " make order " + orderId);
        }

        private void SubscribeMesg()
        {
            _subStatusBool = true;
            _subStatusLabel = "ON";
            RaisePropertyChanged("SubStatus");

            ShowInfoPopupWindow("Subscribed discounts !");
        }

        private void UnsubscribeMesg()
        {
            _subStatusBool = false;
            _subStatusLabel = "OFF";
            RaisePropertyChanged("SubStatus");

            ShowInfoPopupWindow("Unsubscribed discounts !");
        }

        private async Task ProcessDiscountMessage(string message)
        {
            string mesgPrefix = "discount:";
            string discountText = message.Substring(mesgPrefix.Length);
            double.TryParse(discountText, out double discount);
            IList<MerchandiseDto> merchandisesDto = await _manageDataService.GetMerchandises();
            List<Product> products = merchandisesDto.ToList().FromDto();
            ProductsForBasket.Clear();

            foreach (Product product in products)
            {
                ProductsForBasket.Add(product);
            }

            if(BasketEntries.Count > 0)
            {
                List<Entry> temp = BasketEntries.ToList<Entry>();
                BasketEntries.Clear();

                foreach (Entry entry in temp)
                {
                    foreach (Product product in products)
                    {
                        if (entry.Code == product.Id)
                        {
                            entry.NettoPrice = product.NettoPrice;
                            entry.BruttoPrice = CalcHelper.GetBruttoPrice(entry.NettoPrice, entry.Vat);
                            entry.TotalBruttoPrice = CalcHelper.GetTotalBrutto(entry.BruttoPrice, entry.Amount);
                            break;
                        }
                    }
                    BasketEntries.Add(entry);
                }
                double totalBrutto = 0;
                foreach (Entry entry in _basketEntries)
                {
                    totalBrutto += entry.TotalBruttoPrice;
                }
                TotalBruttoPrice = totalBrutto;
        }

            ShowInfoPopupWindow("Products have been updated. Discount percentage: " + Math.Round(discount, 2).ToString());
        }
        #endregion

        #region ButtonsAction
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
                    if (amountNum > 0)
                    {
                        int entryNum = 1;
                        if (entries.Count > 1)
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
                            foundEntry.Amount += amountNum;
                            List<Entry> temp = _basketEntries.ToList<Entry>();
                            _basketEntries.Clear();
                            foreach (Entry entry in temp)
                                _basketEntries.Add(entry);
                        }

                        TotalBruttoPrice = 0;
                        foreach (Entry entry in _basketEntries)
                            TotalBruttoPrice += entry.TotalBruttoPrice;
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

            TotalBruttoPrice = 0;
            foreach (Entry entry in _basketEntries)
                TotalBruttoPrice += entry.TotalBruttoPrice;
        }

        public void ClearBasket()
        {
            _basketEntries.Clear();
            TotalBruttoPrice = 0;

        }

        public void ConfirmBasket()
        {
            if (_basketEntries.Count > 0)
            {
                int.TryParse(_customerPhone, out int phone);
                if (!string.IsNullOrEmpty(_customerName) && !string.IsNullOrWhiteSpace(_customerName) &&
                    !string.IsNullOrEmpty(_customerAddress) && !string.IsNullOrWhiteSpace(_customerAddress) &&
                    phone > 0)
                {
                    Customer customer = new Customer(_customerId, _customerName, _customerAddress, phone, _customerNip, _customerPesel);
                    List<Entry> basketEntries = _basketEntries.ToList();
                    List<EntryDto> basketEntriesDto = Mapper.ToDto(basketEntries);
                    OrderSummary orderSummary = new OrderSummary();
                    orderSummary.TotalBrutto = CalcHelper.GetTotalBrutto(basketEntriesDto);
                    OrderDto orderDto = orderSummary.ToDto(customer, basketEntries);
                    Task.Factory.StartNew(async () => await _manageDataService.communicationService.ApplyOrder(orderDto));
                }
            }
            else
            {
                ShowInfoPopupWindow("Basket cannot be empty");
            }
        }

        public void SearchCustomer()
        {
            if (!string.IsNullOrEmpty(_customerId) && !string.IsNullOrWhiteSpace(_customerId))
            {
                Task.Factory.StartNew(async () => await _manageDataService.communicationService.AskForCustomer(_customerId));
            }
        }

        public void SearchOrder()
        {
            try
            {
                if(!string.IsNullOrEmpty(_searchOrderCode) && !string.IsNullOrWhiteSpace(_searchOrderCode))
                {
                    Task.Factory.StartNew(async () => await _manageDataService.communicationService.AskForOrder(_searchOrderCode));
                }
            }
            catch(Exception e)
            {
                ShowErrorPopupWindow(e.Message);
            }
        }

        public void SubscriptionStatusChange()
        {
            if (!_subStatusBool)
            {
                Task.Factory.StartNew(async () => await _manageDataService.communicationService.AskForSubscription());
            }
            else
            {
                Task.Factory.StartNew(async () => await _manageDataService.communicationService.AskForUnsubscription());
            }

        }
        #endregion

        #region MessageLog
        public void ProcessLog(string message)
        {
            string errorPrefix = "ERROR:";
            if (message.StartsWith(errorPrefix))
            {
                ShowErrorPopupWindow(message.Substring(errorPrefix.Length));
            }
            else
            {
                ShowInfoPopupWindow(message);
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
        #endregion
    }
}
