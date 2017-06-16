using Effort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SJVN.Librarius.Domain.Entities;
using SJVN.Librarius.Domain.Repositories;
using SJVN.Librarius.Infrastructure;
using SJVN.Librarius.Infrastructure.DatabaseContext;
using SJVN.Librarius.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.InfrastructureTests.Repositories
{
    [TestClass]
    public class BookRepositoryTest
    {
        [TestMethod]
        public void BookRepository_AccessDatabase_ReturnException()
        {
            IDatabaseContext dbContext = new LibrariusDbContext(DbConnectionFactory.CreateTransient());

            ICollection<Book> books = dbContext.Books.ToArray();

            Assert.AreEqual(0, books.Count);
        }

        [TestMethod]
        public void GetById_ProvideInvalidId_ReturnNull()
        {
            IDatabaseContext dbContext = new LibrariusDbContext(DbConnectionFactory.CreateTransient());
            var bookRepos = new BookRepository(dbContext);

            var book = bookRepos.GetById(10);

            Assert.IsNull(book);
        }

        [TestMethod]
        public void GetById_ProvidePredefinedId_ReturnException()
        {
            const int bookId = 1;
            IDatabaseContext dbContext = new LibrariusDbContext(DbConnectionFactory.CreateTransient());
            dbContext.Books.Add(new Book { Title = "sample-test", Id = bookId });
            dbContext.SaveChanges();

            var bookRepos = new BookRepository(dbContext);

            var book = bookRepos.GetById(bookId);

            Assert.IsNotNull(book);
            Assert.AreEqual("sample-test", book.Title);
        }
    }
}