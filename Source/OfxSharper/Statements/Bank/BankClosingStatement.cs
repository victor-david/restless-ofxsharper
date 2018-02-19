using Restless.OfxSharper.Account;
using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents a closing statement for a bank account. May contain multiple closing statement details.
    /// </summary>
    public class BankClosingStatement : CommonStatementBase
    {
        #region Public properties
        /// <summary>
        /// Gets the statement type.
        /// </summary>
        public override StatementType StatementType => StatementType.Bank;

        /// <summary>
        /// Gets the account associated with this statement
        /// </summary>
        [NodeInfo("BANKACCTFROM")]
        public BankAccount Account
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the closing statement periods represented in this closing statement.
        /// </summary>
        [NodeInfo("CLOSING", Required = false)]
        public ClosingStatementPeriodCollection<BankClosingStatementPeriod> Periods
        {
            get;
            private set;
        }



        #endregion

        /************************************************************************/

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BankClosingStatement"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal BankClosingStatement(XmlNode rootNode) : base(rootNode)
        {
            if (rootNode != null)
            {
                Account = new BankAccount(GetNestedNode(rootNode, GetNodeName(nameof(Account))));
                Periods = new ClosingStatementPeriodCollection<BankClosingStatementPeriod>(GetNestedNode(rootNode, GetNodeName(nameof(Periods))), DefaultCurrency);
            }
        }
        #endregion
    }
}
