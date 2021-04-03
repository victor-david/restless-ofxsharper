namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Provides enumerated values for the type associated with <see cref="CommonStatementBase"/>.
    /// </summary>
    public enum StatementType
    {
        /// <summary>
        /// The statement type is unspecified.
        /// </summary>
        Unspecified = 0,
        /// <summary>
        /// A bank account (checking, savings) statement.
        /// </summary>
        Bank = 1,
        /// <summary>
        /// A credit card account statement.
        /// </summary>
        CreditCard = 2,
        /// <summary>
        /// An investment account statement.
        /// </summary>
        Investment = 3,

    }
}
