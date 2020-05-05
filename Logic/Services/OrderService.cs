using Data.Interfaces;
using Data.Model;
using Data.Repositories;
using Logic.Dto;
using Logic.Events;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Logic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IdGenerator _idGenerator;
        private readonly IRepository<Order> _orderRepository;
        private readonly ICustomerService _customerService;
        private readonly IMerchandiseService _merchandiseService;
        private readonly CyclicDiscountService _cyclicDiscountService;
        private readonly object m_SyncObject = new object();

        public ICustomerService CustomerService => _customerService;

        public IMerchandiseService MerchandiseService => _merchandiseService;

        public CyclicDiscountService CyclicDiscountService => _cyclicDiscountService;

        public OrderService()
        {
            _idGenerator = new IdGenerator();
            _customerService = new CustomerService();
            _merchandiseService = new MerchandiseService();
            _orderRepository = new OrderRepository();
            _cyclicDiscountService = new CyclicDiscountService(0.3, TimeSpan.FromSeconds(5));
            _cyclicDiscountService.Handler += GiveDiscount;
            _cyclicDiscountService.Start();
        }

        public OrderService(IRepository<Order> orderRepository, ICustomerService customerService, IMerchandiseService merchandiseService, CyclicDiscountService cyclicDiscountService)
        {
            _idGenerator = new IdGenerator();
            _orderRepository = orderRepository;
            _customerService = customerService;
            _merchandiseService = merchandiseService;
            _cyclicDiscountService = cyclicDiscountService;
            _cyclicDiscountService.Handler += GiveDiscount;
            _cyclicDiscountService.Start();
        }

        public OrderDto GetOrder(string id)
        {
            Order order = _orderRepository.Get(id);
            return order.ToDto();  
        }

        public void SaveOrder(OrderDto order)
        {
            lock (m_SyncObject)
            {
                if (string.IsNullOrEmpty(order.Id))
                {
                    string newCustomerId = _idGenerator.GetNextOrderId();
                    order.Id = newCustomerId;
                    Order orderToSave = order.FromDto();
                    _orderRepository.Add(orderToSave);
                }
                else
                {
                    Order orderToSave = order.FromDto();
                    _orderRepository.Add(orderToSave);
                }
            } 
        }

        public void CancelOrder(string id)
        {
            lock (m_SyncObject)
            {
                Order order = _orderRepository.Get(id);

                if (order.Status <= Status.IN_PROGRESS)
                {
                    _orderRepository.Delete(id);
                }
                else
                {
                    throw new Exception("Order has been sent. It is too late to cancel.");
                }
            }  
        }

        public void GiveDiscount(object sender, DiscountEvent e)
        {
            List<MerchandiseDto> merchandises = _merchandiseService.GetMerchandises().ToList();
            foreach (MerchandiseDto merchandise in merchandises)
            {
                merchandise.NettoPrice = merchandise.NettoPrice - (merchandise.NettoPrice * e.Discount);
                _merchandiseService.UpdateMerchandise(merchandise);
            }
        }
    }
}
