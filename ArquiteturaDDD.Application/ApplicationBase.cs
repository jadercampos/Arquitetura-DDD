using System;
using System.Collections.Generic;
using ArquiteturaDDD.Domain.Interfaces.Application;
using ArquiteturaDDD.Domain.Interfaces.Service;

namespace ArquiteturaDDD.Application
{
    public class ApplicationBase<TEntity> : IApplicationBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _service;

        public ApplicationBase(IServiceBase<TEntity> service)
        {
            _service = service;
        }
        public void Add(TEntity entity)
        {
            _service.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _service.Delete(entity);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public TEntity Get(int id)
        {
            return _service.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public void SaveChanges()
        {
            _service.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _service.Update(entity);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _service.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ApplicationBase() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
