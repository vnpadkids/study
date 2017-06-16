using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.Domain.Repositories
{
    /// <summary>
    /// Unit of Work is referred to as a single transaction that involves multiple operations of insert/update/delete and so on kinds.
    /// <see cref="http://www.c-sharpcorner.com/UploadFile/b1df45/unit-of-work-in-repository-pattern/"/> 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit changes to Database
        /// </summary>
        void SaveChanges();
    }
}