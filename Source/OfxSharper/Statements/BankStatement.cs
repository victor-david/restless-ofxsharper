using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents a single statement repsonse for a bank statement.
    /// </summary>
    public class BankStatement : StatementBase
    {
        #region Public properties
        /// <summary>
        /// Gets the statement type.
        /// </summary>
        public override StatementType StatementType => StatementType.Bank;

        /// <summary>
        /// Gets the account associated with this statement
        /// </summary>
        [NodeInfo("BANKACCTFROM", Required = true)]
        public BankAccount Account
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the closing statement if it exists.
        /// </summary>
        [NodeInfo("STMTENDTRNRS", Required = false)]
        public BankClosingStatement Closing
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="BankStatement"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal BankStatement(XmlNode rootNode) : base(rootNode)
        {
            if (rootNode != null)
            {
                Account = new BankAccount(GetNestedNode(rootNode, GetNodeName(nameof(Account))));

                if (NodeExists(rootNode.NextSibling, GetNodeName(nameof(Closing))))
                {
                    Closing = new BankClosingStatement(rootNode.NextSibling);
                }
            }
        }
        #endregion
    }
}
