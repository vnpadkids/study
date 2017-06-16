using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.Domain.Entities
{
    /// <summary>
    /// Represent Book information
    /// </summary>
    public class Book : Entity
    {
        public Book()
        {
            this.BookCopies = new HashSet<BookCopy>();
            this.PublicationDate = DateTime.MinValue;
        }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ISBN10 { get; set; }
        public string ISBN13 { get; set; }

        public string OriginalTitle { get; set; }

        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public string PublicationPlace { get; set; }
        public int PublicationTimes { get; set; }

        public string Dimensions { get; set; }
        public string Weight { get; set; }
        public int PageCount { get; set; }
        public string PageSize { get; set; }
        public string Languages { get; set; }

        public string Authors { get; set; }
        public string AuthorsAbbreviation { get; set; }

        public string Translators { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
        public string Summary { get; set; }

        public int CategoryId { get; set; }
        // public virtual Category Category { get; set; }

        public virtual ICollection<BookCopy> BookCopies { get; set; }
    }
}
