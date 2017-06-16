using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.Domain.Entities
{
    /// <summary>
    /// Represent book's category
    /// </summary>
    public class Category : Entity
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        public string Name { get; set; }

        /// <summary>
        /// Dewey Decimal Classification. <see cref="https://en.wikipedia.org/wiki/Dewey_Decimal_Classification"/>
        /// </summary>
        public string DDC { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
