namespace SJVN.Librarius.Domain.Entities
{
    /// <summary>
    /// Represent BookCopy's available state
    /// </summary>
    public enum BookCopyAvailability : byte
    {
        /// <summary>
        /// Book is unavailable
        /// </summary>
        Unavailable = 0,

        /// <summary>
        /// Book is available for reading at store only
        /// </summary>
        AvailableForReading = 1,

        /// <summary>
        /// Book is available for renting to home
        /// </summary>
        AvailableForRenting = 2,

    }
}