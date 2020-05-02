using Data.Interfaces;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class MerchandiseRepository : IRepository<Merchandise>
    {
        private readonly DataContext _dataContext;

        public MerchandiseRepository()
        {
            _dataContext = new DataContext();
        }

        public MerchandiseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public MerchandiseRepository(DataContext dataContext, IDataFiller dataFiller)
        {
            _dataContext = dataContext;
            dataFiller.Fill(_dataContext);
        }

        public IEnumerable<Merchandise> Get()
        {
            return _dataContext.Merchandises.Values;
        }

        public Merchandise Get(string id)
        {
            _dataContext.Merchandises.TryGetValue(id, out Merchandise merchandise);

            if (merchandise == null)
            {
                throw new KeyNotFoundException("Merchandise not found !");
            }

            return merchandise;
        }

        public void Add(Merchandise entity)
        {
            if (!_dataContext.Merchandises.ContainsKey(entity.Id))
            {
                _dataContext.Merchandises.Add(entity.Id, entity);
            }
            else
            {
                throw new Exception("You're trying to add the existing merchandise with id: " + entity.Id);
            }
        }

        public void Delete(string id)
        {
            if (_dataContext.Merchandises.ContainsKey(id))
            {
                _dataContext.Merchandises.Remove(id);
            }
            else
            {
                throw new Exception("You're trying to delete merchandise with non-existing id.");
            }
        }

        public void Update(string id, Merchandise entity)
        {
            Merchandise merchandise = Get(id);
            merchandise.Name = entity.Name;
            merchandise.Description = entity.Name;
            merchandise.Type = entity.Type;
            merchandise.Unit = entity.Unit;
            merchandise.NettoPrice = entity.NettoPrice;
            merchandise.Vat = entity.Vat;
        }
    }
}
