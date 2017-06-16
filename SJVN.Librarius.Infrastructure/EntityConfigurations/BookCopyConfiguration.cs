using SJVN.Librarius.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.Infrastructure.EntityConfigurations
{
    public class BookCopyConfiguration : EntityConfiguration<BookCopy>
    {
        public BookCopyConfiguration() : base(true)
        {
            HasRequired(x => x.Book).WithMany(x => x.BookCopies).HasForeignKey(x => x.BookId);
        }
    }
}
