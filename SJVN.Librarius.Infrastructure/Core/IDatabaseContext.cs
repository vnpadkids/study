using SJVN.Librarius.Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SJVN.Librarius.Infrastructure
{
    public interface IDatabaseContext : IDisposable
    {
        IDbSet<Book> Books { get; }
        IDbSet<Category> Categories { get; }

        IDbSet<T> Set<T>() where T: Entity;

        DbEntityEntry Entry(object entity);

        int SaveChanges();
    }
}