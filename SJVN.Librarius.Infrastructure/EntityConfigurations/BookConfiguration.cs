using SJVN.Librarius.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.Infrastructure.EntityConfigurations
{
    public class BookConfiguration : EntityConfiguration<Book>
    {
        public BookConfiguration() : base(true)
        {
            // HasRequired(x => x.Category).WithMany(x => x.Books).WillCascadeOnDelete(false);
            HasMany(x => x.BookCopies).WithRequired(x => x.Book).HasForeignKey(x => x.BookId);
            HasMany(x => x.Topics).WithMany(x => x.Books).Map(x => x.ToTable("BookTopics"));
            Property(x => x.Title).IsRequired();
        }
    }
}
