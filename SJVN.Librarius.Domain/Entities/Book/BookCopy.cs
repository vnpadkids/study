using System;

namespace SJVN.Librarius.Domain.Entities
{
    /// <summary>
    /// Represent book copy in library
    /// </summary>
    public class BookCopy : Entity
    {
        public BookCopy()
        {
            this.Availability = BookCopyAvailability.Unavailable;
            this.StoredDate = DateTime.Now;
        }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        /// <summary>
        /// Date to store book in warehouse
        /// </summary>
        public BookCopyAvailability Availability { get; set; }
        public DateTime StoredDate { get; set; }
    }
}