using System;
using System.ComponentModel;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Describes the supported types of accounts that are of AccountType.Bank
    /// </summary>
    public enum BankAccountType
    {
        // Note: Do not change the names of these enumerations. 
        // They are used via Enum.GetName(typeof(BankAccountType), value).ToUpperInvariant()
        // to provide the needed text of an Ofx request.

        /// <summary>
        /// The bank type is not applicable to the <see cref="AccountType"/>.
        /// </summary>
        NotApplicable,
        /// <summary>
        /// A checking account
        /// </summary>
        Checking,
        /// <summary>
        /// A savings account.
        /// </summary>
        Savings,
        /// <summary>
        /// A money market account
        /// </summary>
        MoneyMrkt,
        /// <summary>
        /// A line of credit
        /// </summary>
        CreditLine,
        /// <summary>
        /// A home loan.
        /// </summary>
        HomeLoan,
        /// <summary>
        /// The bank account type is invalid or unknown.
        /// </summary>
        InvalidOrUnknown,
    }

    internal static class BankAccountTypeExtension
    {
        internal static BankAccountType ToBankAccountType(this string str)
        {
            try
            {
                return (BankAccountType)Enum.Parse(typeof(BankAccountType), str, true);
            }
            catch (Exception)
            {

                return BankAccountType.InvalidOrUnknown;
            }
        }
    }
}