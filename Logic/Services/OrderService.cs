using Data.Interfaces;
using Data.Model;
using Data.Repositories;
using Logic.Dto;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
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
        private readonly object m_SyncObject = new object();

        public ICustomerService CustomerService => _customerService;

        public IMerchandiseService MerchandiseService => _merchandiseService;

        public OrderService()
        {
            _customerService = new CustomerService();
            _merchandiseService = new MerchandiseService();
            _orderRepository = new OrderRepository();
        }

        public OrderService(IRepository<Order> orderRepository, ICustomerService customerService, IMerchandiseService merchandiseService)
        {
            _idGenerator = new IdGenerator();
            _orderRepository = orderRepository;
            _customerService = customerService;
            _merchandiseService = merchandiseService;
        }

        public OrderDto GetOrder(string id)
        {
            lock (m_SyncObject) //komunikacja sieciowa
            {
                Order order = _orderRepository.Get(id);
                return order.ToDto();
            }    
        }

        public void SaveOrder(OrderDto order)
        {
            string newCustomerId = _idGenerator.GetNextOrderId();
            order.Id = newCustomerId;
            Order orderToSave = order.FromDto();
            _orderRepository.Add(orderToSave);
        }

        public void CancelOrder(string id)
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
}
