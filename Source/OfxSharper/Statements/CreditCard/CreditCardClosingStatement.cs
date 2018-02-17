using Restless.OfxSharper.Accounts;
using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents a closing statement for a credit card account. May contain multiple closing statement details.
    /// </summary>
    public class CreditCardClosingStatement : CommonStatementBase
    {
        #region Public properties
        /// <summary>
        /// Gets the statement type.
        /// </summary>
        public override StatementType StatementType => StatementType.CreditCard;

        /// <summary>
        /// Gets the account associated with this statement
        /// </summary>
        [NodeInfo("CCACCTFROM", Required = true)]
        public CreditCardAccount Account
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the closing statement periods represented in this closing statement.
        /// </summary>
        [NodeInfo("CCCLOSING", Required = false)]
        public ClosingStatementPeriodCollection<CreditCardClosingStatementPeriod> Periods
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardClosingStatement"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal CreditCardClosingStatement(XmlNode rootNode) : base(rootNode)
        {
            if (rootNode != null)
            {
                Account = new CreditCardAccount(GetNestedNode(rootNode, GetNodeName(nameof(Account))));
                Periods = new ClosingStatementPeriodCollection<CreditCardClosingStatementPeriod>(GetNestedNode(rootNode, GetNodeName(nameof(Periods))), DefaultCurrency);
            }
        }
        #endregion
    }
}
