using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJVN.Librarius.Domain.Entities;
using SJVN.Librarius.Domain.Repositories;

namespace SJVN.Librarius.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : Entity
    {
        private readonly IDatabaseContext dbContext;

        public Repository(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T GetById(int id)
        {
            return this.CurrentDbSet.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return this.CurrentDbSet.AsQueryable<T>();
        }

        public void Add(T entity)
        {
            this.CurrentDbSet.Add(entity);
        }

        public void Update(T entity)
        {
            this.DatabaseContext.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            this.CurrentDbSet.Remove(entity);
        }

        /// <summary>
        /// Current database context
        /// </summary>
        public IDatabaseContext DatabaseContext
        {
            get { return this.dbContext; }
        }

        private IDbSet<T> CurrentDbSet
        {
            get { return this.DatabaseContext.Set<T>(); }
        }
    }
}