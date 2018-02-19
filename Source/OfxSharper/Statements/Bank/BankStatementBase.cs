using Restless.OfxSharper.Core;
using System;
using System.Xml;

namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents the base class for a single bank or credit card statement. This class must be inherited.
    /// </summary>
    public abstract class BankStatementBase : CommonStatementBase
    {
        #region Public properties
        /// <summary>
        /// DTSTART. Start date for transaction data, date
        /// </summary>
        [NodeInfo("DTSTART", Required = true)]
        public DateTime StartDate
        {
            get;
            private set;
        }

        /// <summary>
        /// DTEND. Value client should send in next DTSTART request to ensure that it does not miss any transactions, date
        /// </summary>
        [NodeInfo("DTEND", Required = true)]
        public DateTime EndDate
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the transactions for this statement.
        /// </summary>
        [NodeInfo("BANKTRANLIST")]
        public TransactionCollection Transactions
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the ledger balance.
        /// </summary>
        [NodeInfo("LEDGERBAL", Required = true)]
        public Balance Ledger
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the available balance
        /// </summary>
        [NodeInfo("AVAILBAL", Required = true)]
        public Balance Available
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (protected)
        /// <summary>
        /// Initializes a new instance of the <see cref="BankStatementBase"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        protected BankStatementBase(XmlNode rootNode) : base(rootNode)
        {
            if (rootNode != null)
            {
                StartDate = GetDateTimeValue(rootNode, nameof(StartDate));
                EndDate = GetDateTimeValue(rootNode, nameof(EndDate));
                Ledger = new Balance(GetNestedNode(rootNode, GetNodeName(nameof(Ledger))));
                Available = new Balance(GetNestedNode(rootNode, GetNodeName(nameof(Available))));
                Transactions = new TransactionCollection(GetNestedNode(rootNode, GetNodeName(nameof(Transactions))), this);
            }
        }
        #endregion
    }
}
