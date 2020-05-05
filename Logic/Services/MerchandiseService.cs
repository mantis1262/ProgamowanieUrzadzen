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

        public MerchandiseDto GetMerchandise(string id)
        {
            Merchandise merchandise = _merchandiseRepository.Get(id);
            return merchandise.ToDto();
        }

        public IEnumerable<MerchandiseDto> GetMerchandises()
        {
            List<Merchandise> merchandises = _merchandiseRepository.Get().ToList();
            return merchandises.ToDto();
        }

        public void SaveMerchandise(MerchandiseDto merchandise)
        {
            lock (m_SyncObject)
            {
                Merchandise merchandiseToSet = merchandise.FromDto();
                _merchandiseRepository.Add(merchandiseToSet);
            }  
        }

        public void UpdateMerchandise(MerchandiseDto merchandise)
        {
            lock (m_SyncObject)
            {
                Merchandise merchandiseToSet = merchandise.FromDto();
                _merchandiseRepository.Update(merchandiseToSet.Id, merchandiseToSet);
            }
        }
    }
}
