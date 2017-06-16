using SJVN.Librarius.Domain.Entities;
using SJVN.Librarius.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseContext dbContext)
            : base(dbContext)
        {
        }
    }
}
