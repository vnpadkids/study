using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SJVN.Librarius.Domain.Services;
using Moq;
using SJVN.Librarius.Domain.Repositories;
using SJVN.Librarius.Domain.Entities;

namespace SJVN.Librarius.DomainTests.Services
{
    [TestClass]
    public class BookServiceTests
    {
        [TestMethod]
        public void GetById_WhenBookUnavailable_ReturnNull()
        {
            var bookRepos = new Mock<IBookRepository>();

            IBookService bookService = new BookService(bookRepos.Object);

            var book = bookService.GetBookById(1);

            Assert.IsNull(book);

        }

        [TestMethod]
        public void GetById_WhenBookAvailable_ReturnValidEntity()
        {
            int bookId = 10;
            var bookRepos = new Mock<IBookRepository>();
            bookRepos.Setup(x => x.GetById(10)).Returns(new Book { Id = bookId });

            IBookService bookService = new BookService(bookRepos.Object);

            var book = bookService.GetBookById(bookId);
            
            Assert.IsNotNull(book);
            Assert.AreEqual(bookId, book.Id);
        }
    }
}
