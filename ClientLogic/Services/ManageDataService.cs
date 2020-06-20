using ClientData.Interfaces;
using ClientData.Model;
using ClientData.Respositories;
using ClientLogic.Dto;
using ClientLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace ClientLogic.Services
{
    public class ManageDataService : IService
    {
        private readonly IRepository _dataRepository;
        private readonly object m_SyncObject = new object();
        private Action<string> _log;
        private readonly ICommunicationService communicationService;
        public ISubject<string> messageChain;

        public ManageDataService(Action<string> logger, string uri)
        {
            _dataRepository = new Repository();
            _log = logger;
            messageChain = new Subject<string>();
            communicationService = new CommunicationService(_dataRepository, _log, uri, messageChain);
        }

        public ManageDataService(IRepository dataRepository, Action<string> logger, string uri)
        {
            _dataRepository = dataRepository;
            messageChain = new Subject<string>();
            communicationService = new CommunicationService(_dataRepository, _log, uri, messageChain);
            _log = logger;
        }

        public async Task StartServer()
        {
            await communicationService.CreateConnection();
        }

        public void DisconnectServer()
        {
            communicationService.CloseConnection();
        }

        public async Task<CustomerDto> GetCurrentCustomer(string customerId)
        {
            Customer customerResponse = await communicationService.AskForCustomer(customerId);
            CustomerDto customerDto = new CustomerDto();
            await Task.Factory.StartNew(() =>
            {
                lock (m_SyncObject)
                {
                    _dataRepository.RefreshCurrentCustomer(customerResponse);
                    customerDto = _dataRepository.GetCurrentCustomer().ToDto();
                }

            });
            return customerDto;
        }

        public async Task<IList<MerchandiseDto>> GetMerchandises()
        {
            IList<Merchandise> merchandisesResponse = await communicationService.AskForMerchandises();
            List<MerchandiseDto> merchandisesDto = new List<MerchandiseDto>();
            await Task.Factory.StartNew(() =>
            {
                lock (m_SyncObject)
                {
                    _dataRepository.RefreshMerchandises(merchandisesResponse);
                    merchandisesDto = _dataRepository.GetMerchandises().ToList().ToDto();
                }
            });
            return merchandisesDto;
        }

        public IList<MerchandiseDto> GetLocalMerchandises()
        {
            return _dataRepository.GetMerchandises().ToList().ToDto();
        }

        public async Task<OrderDto> GetCurrentOrder(string orderId)
        {
            Order orderResponse = await communicationService.AskForOrder(orderId);
            OrderDto orderDto = new OrderDto();
            await Task.Factory.StartNew(() =>
            {
                lock (m_SyncObject)
                {
                    _dataRepository.RefreshCurrentOrder(orderResponse);
                    orderDto = _dataRepository.GetCurrentOrder().ToDto();
                }

            });
            return orderDto;
        }

        public async Task<string> MakeOrder(OrderDto order)
        {
            return await communicationService.ApplyOrder(order);
        }

        public async Task<string> MakeSubscription()
        {
            return await communicationService.AskForSubscription();
        }

        public async Task<string> CancelSubscription()
        {
            return await communicationService.AskForUnsubscription();
        }
    }
}
