using Data.Interfaces;
using Data.Model;
using Data.Repositories;
using System.Linq;
using Logic.Dto;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        private readonly IRepository<Merchandise> _merchandiseRepository;
        private readonly object m_SyncObject = new object();

        public MerchandiseService()
        {
            _merchandiseRepository = new MerchandiseRepository();
        }

        public MerchandiseService(IRepository<Merchandise> merchandiseRepository)
        {
            _merchandiseRepository = merchandiseRepository;
        }

        public async Task<MerchandiseDto> GetMerchandise(string id)
        {
            Merchandise merchandise = await Task.Factory.StartNew(() => _merchandiseRepository.Get(id));
            return merchandise.ToDto();
        }

        public async Task<IEnumerable<MerchandiseDto>> GetMerchandises()
        {  
            List<Merchandise> merchandises = await Task.Factory.StartNew(() => _merchandiseRepository.Get().ToList());
            return merchandises.ToDto();
        }

        public async Task SaveMerchandise(MerchandiseDto merchandise)
        {
            await Task.Factory.StartNew(() => 
            {
                lock (m_SyncObject)
                {
                    Merchandise merchandiseToSet = merchandise.FromDto();
                    _merchandiseRepository.Add(merchandiseToSet);
                }
            });
        }

        public async Task UpdateMerchandise(MerchandiseDto merchandise)
        {
            await Task.Factory.StartNew(() =>
            {
                lock (m_SyncObject)
                {
                    Merchandise merchandiseToSet = merchandise.FromDto();
                    _merchandiseRepository.Update(merchandiseToSet.Id, merchandiseToSet);
                }
            });
        }
    }
}
