using System;
using System.ComponentModel;

namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Provides enumerated values that describe the action that must be taken
    /// for a corrected transaction.
    /// </summary>
    public enum TransactionCorrectionAction
    {
        /// <summary>
        /// No action is required.
        /// </summary>
        None,
        /// <summary>
        /// Replace the transaction with the one referenced by <see cref="Transaction.CorrectedTransactionId"/>.
        /// </summary>
        Replace,
        /// <summary>
        /// Delete the transaction.
        /// </summary>
        Delete,
    }

    internal static class TransactionCorrectionActionExtension
    {
        internal static TransactionCorrectionAction ToTransactionCorrectionAction(this string str)
        {
            if (Enum.TryParse(str, true, out TransactionCorrectionAction result))
            {
                return result;
            }
            return TransactionCorrectionAction.None;
        }
    }
}