namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents the types of investment securities.
    /// </summary>
    public enum SecurityType
    {
        /// <summary>
        /// Identifies a security type of none.
        /// </summary>
        None,
        /// <summary>
        /// Identifies a security held in a mutual fund.
        /// </summary>
        MutualFund,
        /// <summary>
        /// Identifies a security held in stocks.
        /// </summary>
        Stock,
        /// <summary>
        /// Identifies a security held as debt.
        /// </summary>
        Debt,
        /// <summary>
        /// Identifies a security held as an option.
        /// </summary>
        Option,
        /// <summary>
        /// Identifies a security of another type, none of the above.
        /// </summary>
        Other,
    }
}
