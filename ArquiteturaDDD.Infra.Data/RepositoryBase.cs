using System.Collections.Generic;
using ArquiteturaDDD.Domain.Interfaces.Repository;
using ArquiteturaDDD.Infra.Data.EF.Config;
using System.Data.Entity;
using System;
using ArquiteturaDDD.Domain.Enums;

namespace ArquiteturaDDD.Infra.Data
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected AppDbContext Context { get; private set; }

        public RepositoryBase()
        {
            Context = new AppDbContext();
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        protected void FullDelete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        protected void FullDelete(int id)
        {
            Context.Set<TEntity>().Remove(Get(id));
        }

        protected void LogicDelete(TEntity entity)
        {
            Context.Entry(entity).Property("StatusDbAuditTrail").CurrentValue = StatusDbAuditTrail.Excluido;
            Context.Entry(entity).State = EntityState.Modified;
        }

        protected void LogicDelete(int id)
        {
            Context.Entry(Get(id)).Property("StatusDbAuditTrail").CurrentValue = StatusDbAuditTrail.Excluido;
            Context.Entry(Get(id)).State = EntityState.Modified;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                    this.Context = null;
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);

        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
