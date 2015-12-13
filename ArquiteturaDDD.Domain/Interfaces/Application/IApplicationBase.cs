using System;
using System.Collections.Generic;

namespace ArquiteturaDDD.Domain.Interfaces.Application
{
    public interface IApplicationBase<TEntity> : IDisposable where TEntity : class
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
