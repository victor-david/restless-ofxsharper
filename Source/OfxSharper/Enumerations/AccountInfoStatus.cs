namespace Restless.OfxSharper
{
    /// <summary>
    /// Provides an enumeration that describes the status of an account info
    /// </summary>
    public enum AccountInfoStatus
    {
        /// <summary>
        /// The status is unknown.
        /// </summary>
        InvalidOrUnknown,
        /// <summary>
        ///  AVAIL. Available, but not yet requested
        /// </summary>
        Available,
        /// <summary>
        /// PEND. Requested, but not yet available
        /// </summary>
        Pending,
        /// <summary>
        /// ACTIVE. In use.
        /// </summary>
        Active
    }

    internal static class AccountInfoStatusExtension
    {
        internal static AccountInfoStatus ToAccountInfoStatus(this string str)
        {
            switch (str.ToUpperInvariant())
            {
                case "AVAIL":
                    return AccountInfoStatus.Available;
                case "PEND":
                    return AccountInfoStatus.Pending;
                case "ACTIVE":
                    return AccountInfoStatus.Active;
                default:
                    return AccountInfoStatus.InvalidOrUnknown;
            }
        }
    }
}
