namespace Restless.OfxSharper
{
    /// <summary>
    /// Defines an interface account to use with <see cref="OfxRequestBuilder"/>.
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the bank id.
        /// </summary>
        string BankId { get; set; }

        /// <summary>
        /// Gets or sets the account type.
        /// </summary>
        AccountType AccountType { get; set; }

        /// <summary>
        /// Gets or sets the bank account type.
        /// </summary>
        BankAccountType BankAccountType { get; set; }

    }
}
