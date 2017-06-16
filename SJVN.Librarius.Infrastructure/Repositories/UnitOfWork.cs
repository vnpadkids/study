using SJVN.Librarius.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.Infrastructure
{
    /// <summary>
    /// UnitOfWork's implementation
    /// <see cref="http://www.reflectivesoftware.com/2015/07/26/unit-of-work-entity-framework-unity-ddd-hexagonal-onion/"/>
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext databaseContext;
        private bool _disposed = false;

        public UnitOfWork(IDatabaseContext dbContext)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

            this.databaseContext = dbContext;
        }

        public void SaveChanges()
        {
            databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && databaseContext != null)
            {
                databaseContext.Dispose();
            }

            _disposed = true;
        }

    }
}
