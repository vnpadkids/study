using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJVN.Librarius.Domain.Entities;
using SJVN.Librarius.Domain.Repositories;

namespace SJVN.Librarius.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public Book GetBookById(int bookId)
        {
            return bookRepository.GetById(bookId);
        }
    }
}
