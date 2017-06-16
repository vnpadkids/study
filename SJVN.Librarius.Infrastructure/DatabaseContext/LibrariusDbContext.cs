using SJVN.Librarius.Domain.Entities;
using SJVN.Librarius.Infrastructure.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace SJVN.Librarius.Infrastructure.DatabaseContext
{
    public class LibrariusDbContext : DbContext, IDatabaseContext
    {
        public LibrariusDbContext()
            : this("Data Source=Librarius.sdf;Persist Security Info=False;")
        {

        }
        public LibrariusDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        /// <summary>
        /// For testing purpose only
        /// </summary>
        /// <param name="dbConnection">Entity Database Connection</param>
        public  LibrariusDbContext(System.Data.Common.DbConnection dbConnection)
            : base(dbConnection, true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var configurationAssembly = Assembly.GetExecutingAssembly();

            modelBuilder.Configurations.AddFromAssembly(configurationAssembly);

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Book> Books
        {
            get { return base.Set<Book>(); }
        }

        public IDbSet<Category> Categories
        {
            get { return base.Set<Category>(); }
        }

        IDbSet<T> IDatabaseContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}
