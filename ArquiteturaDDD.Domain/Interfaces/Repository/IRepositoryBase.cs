using System;
using System.Collections.Generic;

namespace ArquiteturaDDD.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> :IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Delete(TEntity entity);
        void Delete(int id);
        void SaveChanges();
    }
}
