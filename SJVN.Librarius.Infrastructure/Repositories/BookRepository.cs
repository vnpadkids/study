using SJVN.Librarius.Domain.Entities;
using SJVN.Librarius.Domain.Repositories;

namespace SJVN.Librarius.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(IDatabaseContext dbContext)
            : base(dbContext)
        {
        }
    }
}