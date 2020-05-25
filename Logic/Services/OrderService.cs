﻿using Data;
using Data.Interfaces;
using Data.Model;
using Logic.Observer;
using Data.Repositories;
using Logic.Dto;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly ICustomerService _customerService;
        private readonly IMerchandiseService _merchandiseService;
        private DiscountCreator _provider = new DiscountCreator();
        private readonly CyclicDiscountService _cyclicDiscountService;
        private readonly object m_SyncObject = new object();

        public ICustomerService CustomerService => _customerService;

        public IMerchandiseService MerchandiseService => _merchandiseService;

        public CyclicDiscountService CyclicDiscountService => _cyclicDiscountService;

        public OrderService()
        {
            _customerService = new CustomerService();
            _merchandiseService = new MerchandiseService();
            _orderRepository = new OrderRepository();
            _cyclicDiscountService = new CyclicDiscountService(0.3, TimeSpan.FromSeconds(20), _provider);
            _cyclicDiscountService.Start();
        }

        public OrderService(IRepository<Order> orderRepository, ICustomerService customerService, IMerchandiseService merchandiseService, CyclicDiscountService cyclicDiscountService)
        {
            _orderRepository = orderRepository;
            _customerService = customerService;
            _merchandiseService = merchandiseService;
            _cyclicDiscountService = cyclicDiscountService;
            _provider = _cyclicDiscountService.Provider;
            _cyclicDiscountService.Start();
        }

        public OrderService(bool useDataFiller)
        {

            if (useDataFiller)
            {
                DataContext dataContext = new DataContext();
                IDataFiller dataFiller = new DataFactory();
                dataFiller.Fill(dataContext);
                IdGenerator.ClientNum = dataContext.Customers.Count+1;
                IdGenerator.OrderNum = dataContext.Orders.Count+1;
                CustomerRepository customerRepository = new CustomerRepository(dataContext);
                MerchandiseRepository merchandiseRepository = new MerchandiseRepository(dataContext);
                OrderRepository orderRepository = new OrderRepository(dataContext);
                ICustomerService customerService = new CustomerService(customerRepository);
                IMerchandiseService merchandiseService = new MerchandiseService(merchandiseRepository);
                _orderRepository = orderRepository;
                _customerService = customerService;
                _merchandiseService = merchandiseService;
            }
            else
            {
                _customerService = new CustomerService();
                _merchandiseService = new MerchandiseService();
                _orderRepository = new OrderRepository();
            }
            _cyclicDiscountService = new CyclicDiscountService(0.3, TimeSpan.FromSeconds(20), _provider);
            _cyclicDiscountService.Start();
        }

        public async Task<OrderDto> GetOrder(string id)
        {
            Order order = await Task.Factory.StartNew(() => _orderRepository.Get(id));
            return order.ToDto();  
        }

        public async Task<string> SaveOrder(OrderDto order)
        {
            string newOrderId = "";
            await Task.Factory.StartNew(() => 
            {
                lock (m_SyncObject)
                {
                    if (string.IsNullOrEmpty(order.Id))
                    {
                        newOrderId = IdGenerator.GetNextOrderId();
                        order.Id = newOrderId;
                        Order orderToSave = order.FromDto();
                        _orderRepository.Add(orderToSave);
                    }
                    else
                    {
                        Order orderToSave = order.FromDto();
                        _orderRepository.Add(orderToSave);
                    }
                }
            });
            return newOrderId;
        }

        public async Task CancelOrder(string id)
        {
            await Task.Factory.StartNew(() => 
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
            }); 
        }
    }
}
