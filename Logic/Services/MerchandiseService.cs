﻿using Data.Interfaces;
using Data.Model;
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

        public MerchandiseService(IRepository<Merchandise> merchandiseRepository)
        {
            _merchandiseRepository = merchandiseRepository;
        }

        public MerchandiseDto GetMerchandise(string id)
        {
            lock (m_SyncObject) //komunikacja sieciowa
            {
                Merchandise merchandise = _merchandiseRepository.Get(id);
                return merchandise.ToDto();
            }
        }

        public IEnumerable<MerchandiseDto> GetMerchandises(string id)
        {
            lock (m_SyncObject) //komunikacja sieciowa
            {
                List<Merchandise> merchandises = _merchandiseRepository.Get() as List<Merchandise>;
                return merchandises.ToDto();
            }
        }
    }
}