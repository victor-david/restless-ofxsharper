using System.ComponentModel;

namespace Restless.OfxSharper
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
}