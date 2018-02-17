namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents the types of investment securities.
    /// </summary>
    /// <remarks>
    /// Integer values are explicitly assigned to each enumeration for clarity.
    /// These values may get stored by downstream processing. They must not change.
    /// </remarks>
    public enum SecurityType
    {
        /// <summary>
        /// Identifies a security type of none.
        /// </summary>
        None = 0,
        /// <summary>
        /// Identifies a security held in a mutual fund.
        /// </summary>
        MutualFund = 1,
        /// <summary>
        /// Identifies a security held in stocks.
        /// </summary>
        Stock = 2,
        /// <summary>
        /// Identifies a security held as debt.
        /// </summary>
        Debt = 3,
        /// <summary>
        /// Identifies a security held as an option.
        /// </summary>
        Option = 4,
        /// <summary>
        /// Identifies a security of another type, none of the above.
        /// </summary>
        Other = 5,
    }
}
