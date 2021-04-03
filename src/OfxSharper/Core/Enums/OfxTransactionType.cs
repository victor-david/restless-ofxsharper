using System;
using System.ComponentModel;

namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Provides enumerated values for <see cref="Transaction.TransType"/>
    /// </summary>
    public enum OfxTransactionType
    {
        /// <summary>
        /// The transaction type is unknown.
        /// </summary>
        Unknown,
        /// <summary>
        /// Generic credit
        /// </summary>
        CREDIT,
        /// <summary>
        /// Generic debit
        /// </summary>
        DEBIT,
        /// <summary>
        /// Interest earned or paid, depends on signage of amount
        /// </summary>
        INT,
        /// <summary>
        /// Dividend
        /// </summary>
        DIV,
        /// <summary>
        /// FI fee
        /// </summary>
        FEE,
        /// <summary>
        /// Service charge
        /// </summary>
        SRVCHG,
        /// <summary>
        /// Deposit
        /// </summary>
        DEP,
        /// <summary>
        /// ATM debit or credit, depends on signage of amount
        /// </summary>
        ATM,
        /// <summary>
        /// Point of sale debit or credit, depends on signage of amount
        /// </summary>
        POS,
        /// <summary>
        /// Transfer
        /// </summary>
        XFER,
        /// <summary>
        /// Check
        /// </summary>
        CHECK,
        /// <summary>
        /// Electronic payment
        /// </summary>
        PAYMENT,
        /// <summary>
        /// Cash withdrawal
        /// </summary>
        CASH,
        /// <summary>
        /// Direct deposit
        /// </summary>
        DIRECTDEP,
        /// <summary>
        /// Merchant initiated debit
        /// </summary>
        DIRECTDEBIT,
        /// <summary>
        ///  Repeating payment/standing order
        /// </summary>
        REPEATPMT,
        /// <summary>
        /// Other
        /// </summary>
        OTHER
    }

    internal static class OfxTransactionTypeExtension
    {
        internal static OfxTransactionType ToOfxTransactionType(this string str)
        {
            if (Enum.TryParse(str, true, out OfxTransactionType result))
            {
                return result;
            }
            return OfxTransactionType.Unknown;
        }
    }
}
