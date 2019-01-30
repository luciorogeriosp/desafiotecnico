using ProcessoSeletivoDataContext;
using ProcessoSeletivoDataContext.Interfaces;
using ProcessoSeletivoModel;
using System;
using System.Collections.Generic;

namespace ProcessoSeletivoDataService
{
    public class VagaService : IDisposable
    {
        private readonly IVagaDAL _instancia;

        public VagaService()
        {
            _instancia = IoC<IVagaDAL>.ObterInstancia();

        }

        public void Add(VagaModel entity)
        {
            _instancia.Add(entity);
        }

        public void Update(VagaModel entity)
        {
            _instancia.Update(entity);
        }

        public void Delete(int Id)
        {
            _instancia.Delete(Id);
        }

        public VagaModel GetById(int Id)
        {
            return _instancia.GetById(Id);
        }

        public IEnumerable<VagaModel> ListAll()
        {
            return _instancia.ListAll();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~VagaService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
