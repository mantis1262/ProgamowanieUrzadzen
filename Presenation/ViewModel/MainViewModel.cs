using Logic;
using Logic.Dto;
using Logic.Events;
using Logic.Services;
using Microsoft.VisualBasic;
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

namespace Presenation.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        private Product _currentBasketProduct;
        private Entry _currentBasketEntry;
        private Customer _currentSearchCustomer;
        private OrderSummary _currentSearchOrderSummary;
        private ObservableCollection<Product> _productsForBasket;
        private ObservableCollection<Entry> _basketEntries;
        private ObservableCollection<Entry> _searchEntries;
        private OrderService _orderService;

        private CyclicActionService _cyclicActionService;
        private IObservable<EventPattern<CyclicEvent>> _tickObservable;
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
        
        public Customer CurrentSearchCustomer 
        { 
            get => _currentSearchCustomer; 
            set
            {
                _currentSearchCustomer = value;
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

        public MainViewModel()
        {
            _orderService = new OrderService();
            _currentBasketProduct = null;
            _currentBasketEntry = null;
            _currentSearchCustomer = null;
            _currentSearchOrderSummary = null;
            AddProductToBasketCommand = new RelayCommand(AddProductToBasket);
            _productsForBasket = new ObservableCollection<Product>(_orderService.MerchandiseService.GetMerchandises().ToList().FromDto());
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

        public void AddProductToBasket()
        {
            if (_currentBasketProduct != null)
            {
                List<Entry> entries = _basketEntries.ToList();
                Entry foundEntry = entries.Where(item => item.Code == _currentBasketProduct.Id).FirstOrDefault();
                string input = Interaction.InputBox("Enter product amount", "Amount", "");
                if (!string.IsNullOrEmpty(input))
                {
                    ShowErrorPopupWindow("Amount cannot be empty");
                }
                else
                {
                    if (foundEntry == null)
                    {
                        int entryNum = entries.Max(entry => entry.Id) + 1;
                        double netto = _currentBasketProduct.NettoPrice;
                        double vat = _currentBasketProduct.Vat;
                        double brutto = CalcHelper.GetBruttoPrice(netto, vat);
                        double totalBrutto = CalcHelper.GetTotalBrutto(brutto, entryNum);
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
                            entryNum,
                            brutto,
                            totalBrutto
                        );
                        _basketEntries.Add(newEntry);
                    }
                    else
                    {
                        int.TryParse(input, out int amountNum);
                        foundEntry.Amount += amountNum;
                    }
                }
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
