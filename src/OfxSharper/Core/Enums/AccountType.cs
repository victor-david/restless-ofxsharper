namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Describes the supported type of financial institution accounts.
    /// </summary>
    public enum AccountType
    {
        /// <summary>
        /// The account type is unspecified.
        /// </summary>
        Unspecified = 0,
        /// <summary>
        /// A bank account.
        /// </summary>
        Bank = 1,
        /// <summary>
        /// A credit card account.
        /// </summary>
        CreditCard = 2,
        /// <summary>
        /// An investment account.
        /// </summary>
        Investment = 3,
    }
}