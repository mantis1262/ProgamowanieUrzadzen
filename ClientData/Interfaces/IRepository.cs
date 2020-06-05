using System;
using System.Collections.Generic;
using System.Text;

namespace ClientData.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T Get(string id);
        void Add(T entity);
        void Delete(string id);
        void Update(string id, T entity);
    }
}
