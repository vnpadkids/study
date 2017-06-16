using SJVN.Librarius.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.Domain.Repositories
{
    public interface IRepository<T>
        where T : Entity
    {
        /// <summary>
        /// Get entity by its identity
        /// </summary>
        /// <param name="id">Entity's identity</param>
        /// <returns></returns>
        T GetById(int id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
