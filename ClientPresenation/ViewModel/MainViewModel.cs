using ClientLogic;
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
using System.Threading;

namespace ClientPresentation.ViewModel
{
    internal class MainViewModel : ViewModelBase, IDisposable
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
        private SynchronizationContext _context;

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
            _context = SynchronizationContext.Current;
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

            _manageDataService = new ManageDataService((mesg) => Logs.ProcessLog(mesg), _uriPeer);
            _manageDataService.messageChain.Subscribe(async (mesg) => await ReceiveMessage(mesg));
            Task.Factory.StartNew(async () => 
            {
                await _manageDataService.StartServer();
                await RefreshMerchandises();
            });
        }
        #endregion

        #region Requests
        public async Task ReceiveMessage(string message)
        {
            try
            {
                Debug.WriteLine("[{0}] Client was informed about {1}", DateTime.Now.ToString("HH:mm:ss.fff"), message);
                string outp = String.Empty;

                if (message.StartsWith("ERROR:"))
                {
                    Logs.ProcessLog(message);
                    return;
                }

                switch (message)
                {
                    case "connection_established":
                        {
                            await Task.Factory.StartNew(() => Logs.ProcessLog("Connection established"));
                            break;
                        }
                    case "get_merchandises":
                        {
                            //await RefreshMerchandises();
                            break;
                        }
                }

                if (message.StartsWith("discount"))
                {
                    await ProcessDiscountMessage(message);
                }
            }
            catch(Exception e)
            {
                Logs.ProcessLog("ERROR: " + e.Message);
            }
        }

        private async Task RefreshCustomer()
        {
            try
            {
                CustomerDto customerDto = await _manageDataService.GetCurrentCustomer(_customerId);
                Customer customer = customerDto.FromDto();
                _context.OperationStarted();
                _context.Send(x => CustomerId = customer.Id, null);
                _context.Send(x => CustomerName = customer.Name, null);
                _context.Send(x => CustomerAddress = customer.Address, null);
                _context.Send(x => CustomerPhone = customer.PhoneNumber.ToString(), null);
                _context.Send(x => CustomerNip = customer.Nip, null);
                _context.Send(x => CustomerPesel = customer.Pesel, null);
                _context.OperationCompleted();
                Logs.ProcessLog("Loaded customer info");
            }
            catch(Exception e)
            {
                Logs.ProcessLog("ERROR: " + e.Message);
            }
            
        }

        private async Task RefreshMerchandises()
        {
            try
            {
                IList<MerchandiseDto> merchandisesDto = await _manageDataService.GetMerchandises();
                List<Product> products = merchandisesDto.ToList().FromDto();
                _context.OperationStarted();
                _context.Send(x => ProductsForBasket.Clear(), null);
                foreach (Product product in products)
                {
                    _context.Send(x => ProductsForBasket.Add(product), null);
                }
                _context.OperationCompleted();
                Logs.ProcessLog("Loaded product");
            }
            catch (Exception e)
            {
                Logs.ProcessLog("ERROR: " + e.Message);
            }
        }

        private async Task RefreshOrder()
        {
            try
            {
                OrderDto orderDto = await _manageDataService.GetCurrentOrder(_searchOrderCode);
                Customer customer = orderDto.ClientInfo.FromDto();
                OrderSummary orderSummary = orderDto.FromDto();
                List<Entry> entries = orderDto.Entries.FromDto();
                _context.OperationStarted();
                _context.Send(x => _searchCustomers.Clear(), null);
                _context.Send(x => _searchOrders.Clear(), null);
                _context.Send(x => _searchEntries.Clear(), null);
                _context.Send(x => _searchCustomers.Add(customer), null);
                _context.Send(x => _searchOrders.Add(orderSummary), null);
                foreach (Entry entry in entries)
                {
                    _context.Send(x => _searchEntries.Add(entry), null);
                }
                _context.OperationCompleted();
                Logs.ProcessLog("Loaded order");
            }
            catch (Exception e)
            {
                Logs.ProcessLog("ERROR: " + e.Message);
            }
        }

        private async Task MakeOrder(OrderDto orderDto)
        {
            try
            {
                string response = await _manageDataService.MakeOrder(orderDto);
                string[] parts = response.Split(':');
                string clientId = parts[1];
                string orderId = parts[2];
                CustomerId = clientId;
                Logs.ProcessLog(clientId + " make order " + orderId);
            }
            catch (Exception e)
            {
                Logs.ProcessLog("ERROR: " + e.Message);
            }
        }

        private void SubscribeMesg()
        {
            _subStatusBool = true;
            _subStatusLabel = "ON";
            RaisePropertyChanged("SubStatus");
            Logs.ProcessLog("Subscribed discounts !");
        }

        private void UnsubscribeMesg()
        {
            _subStatusBool = false;
            _subStatusLabel = "OFF";
            RaisePropertyChanged("SubStatus");
            Logs.ProcessLog("Unsubscribed discounts !");
        }

        private async Task ProcessDiscountMessage(string message)
        {
            try
            {
                IList<MerchandiseDto> merchandisesDto = await _manageDataService.GetMerchandises();
                List<Product> products = merchandisesDto.ToList().FromDto();
                _context.OperationStarted();
                _context.Send(x => ProductsForBasket.Clear(), null);

                foreach (Product product in products)
                {
                    _context.Send(x => ProductsForBasket.Add(product), null);
                }

                if (BasketEntries.Count > 0)
                {
                    List<Entry> temp = BasketEntries.ToList<Entry>();
                    _context.Send(x => BasketEntries.Clear(), null);

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
                        _context.Send(x => BasketEntries.Add(entry), null);
                    }
                    double totalBrutto = 0;
                    foreach (Entry entry in _basketEntries)
                    {
                        totalBrutto += entry.TotalBruttoPrice;
                    }
                    _context.Send(x => TotalBruttoPrice = Math.Round(totalBrutto, 2), null);
                }

                RaisePropertyChanged("BasketEntries");
                RaisePropertyChanged("ProductsForBasket");

                _context.OperationStarted();

                Logs.ProcessLog("Products have been updated. " + message);
            }
            catch (Exception e)
            {
                Logs.ProcessLog("ERROR: " + e.Message);
            }
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
                    Logs.ProcessLog("Amount cannot be empty");
                }
                else
                {
                    if (amountNum > 0)
                    {
                        int entryNum = 1;
                        if (entries.Count >= 1)
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
                            foundEntry.TotalBruttoPrice = CalcHelper.GetTotalBrutto(foundEntry.BruttoPrice, foundEntry.Amount);
                            List<Entry> temp = _basketEntries.ToList<Entry>();
                            _basketEntries.Clear();
                            foreach (Entry entry in temp)
                                _basketEntries.Add(entry);
                        }

                        TotalBruttoPrice = 0;
                        foreach (Entry entry in _basketEntries)
                            TotalBruttoPrice += entry.TotalBruttoPrice;
                        TotalBruttoPrice = Math.Round(TotalBruttoPrice, 2);
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
            TotalBruttoPrice = Math.Round(TotalBruttoPrice, 2);
            RaisePropertyChanged("TotalBruttoPrice");
        }

        public void ClearBasket()
        {
            _basketEntries.Clear();
            TotalBruttoPrice = 0;
            RaisePropertyChanged("TotalBruttoPrice");
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
                    Task.Factory.StartNew(async () => await MakeOrder(orderDto));
                    BasketEntries.Clear();
                    TotalBruttoPrice = 0;
                }
            }
            else
            {
                Logs.ProcessLog("Basket cannot be empty");
            }
        }

        public void SearchCustomer()
        {
            if (!string.IsNullOrEmpty(_customerId) && !string.IsNullOrWhiteSpace(_customerId))
            {
                Task.Factory.StartNew(async () => await RefreshCustomer());
            }
        }

        public void SearchOrder()
        {
            try
            {
                if(!string.IsNullOrEmpty(_searchOrderCode) && !string.IsNullOrWhiteSpace(_searchOrderCode))
                {
                    Task.Factory.StartNew(async () => await RefreshOrder());
                }
            }
            catch(Exception e)
            {
                Logs.ProcessLog(e.Message);
            }
        }

        public void SubscriptionStatusChange()
        {
            if (!_subStatusBool)
            {
                Task.WaitAll(Task.Factory.StartNew(async () => Logs.ProcessLog(await _manageDataService.MakeSubscription())));
            }
            else
            {
                Task.WaitAll(Task.Factory.StartNew(async () => Logs.ProcessLog(await _manageDataService.CancelSubscription())));
            }

        }
        #endregion

        public void Dispose()
        {
            _manageDataService.DisconnectServer();
        }
    }
}
