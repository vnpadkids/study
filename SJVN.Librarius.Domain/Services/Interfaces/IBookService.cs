using SJVN.Librarius.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.Domain.Services
{
    public interface IBookService
    {
        Book GetBookById(int bookId);
    }
}
