using Restless.OfxSharper.Account;
using System;
using System.Xml;

namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Represents a transfer aggregate, XFERINFO.
    /// </summary>
    public class TransferInfo : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// Gets the source account.
        /// </summary>
        /// <remarks>
        /// This may be BANKACCTFROM or CCACCTFROM
        /// </remarks>
        public BankAccountBase From
        {
            get;
        }

        /// <summary>
        /// Gets the destination account.
        /// </summary>
        /// <remarks>
        /// This may be BANKACCTFROM or CCACCTFROM
        /// </remarks>
        public BankAccountBase To
        {
            get;
        }

        /// <summary>
        /// Gets the amount of the transfer
        /// </summary>
        [NodeInfo("TRNAMT", Required = true)]
        public Decimal Amount
        {
            get;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferInfo"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal TransferInfo(XmlNode rootNode)
        {
            From = GetAccount(rootNode, "FROM");
            To = GetAccount(rootNode, "TO");
            Amount = GetDecimalValue(rootNode, nameof(Amount));
        }
        #endregion

        /************************************************************************/

        #region Private methods
        private BankAccountBase GetAccount(XmlNode rootNode, string suffix)
        {
            var node = GetNestedNode(rootNode, $"BANKACCT{suffix}");
            if (node != null) return new BankAccount(node);
            node = GetNestedNode(rootNode, $"CCACCT{suffix}");
            if (node != null) return new CreditCardAccount(node);
            throw new OfxParseException("Invalid XFERINFO response structure");
        }
        #endregion
    }
}
