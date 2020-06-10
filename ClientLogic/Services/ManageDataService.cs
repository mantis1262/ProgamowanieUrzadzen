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
        public readonly ICommunicationService communicationService;
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

        public async Task<CustomerDto> GetCurrentCustomer()
        {
            Customer customer = new Customer();
            await Task.Factory.StartNew(() =>
            {
                lock (m_SyncObject)
                {
                    customer = _dataRepository.GetCurrentCustomer();
                }

            });
            return customer.ToDto();
        }

        public async Task<IList<MerchandiseDto>> GetMerchandises()
        {
            List<Merchandise> merchandises = new List<Merchandise>();
            await Task.Factory.StartNew(() =>
            {
                lock (m_SyncObject)
                {
                    merchandises = _dataRepository.GetMerchandises().ToList();
                }

            });
            return merchandises.ToDto();
        }

        public async Task<OrderDto> GetCurrentOrder()
        {
            Order order = new Order();
            await Task.Factory.StartNew(() =>
            {
                lock (m_SyncObject)
                {
                    order = _dataRepository.GetCurrentOrder();
                }

            });
            return order.ToDto();
        }
    }
}
