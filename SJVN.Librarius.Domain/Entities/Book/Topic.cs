using System.Collections.Generic;

namespace SJVN.Librarius.Domain.Entities
{
    /// <summary>
    /// Represent topic of a book.
    /// </summary>
    public class Topic : Entity
    {
        public Topic()
        {
            this.Books = new HashSet<Book>();
        }

        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}