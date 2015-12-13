using System;
using System.Collections.Generic;

namespace ArquiteturaDDD.Domain.Interfaces.Service
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void SaveChanges();
    }
}
