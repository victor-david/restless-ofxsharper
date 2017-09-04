using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents a single statement repsonse for a credit card statement.
    /// </summary>
    public class CreditCardStatement : StatementBase
    {
        #region Public properties
        /// <summary>
        /// Gets the statement type.
        /// </summary>
        public override StatementType StatementType => StatementType.CreditCard;

        /// <summary>
        /// Gets the account associated with this statement
        /// </summary>
        [NodeInfo("CCACCTFROM")]
        public CreditCardAccount Account
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the closing statement if it exists.
        /// </summary>
        [NodeInfo("CCSTMTENDTRNRS")]
        public CreditCardClosingStatement Closing
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardStatement"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal CreditCardStatement(XmlNode rootNode) : base(rootNode)
        {
            if (rootNode != null)
            {
                Account = new CreditCardAccount(GetNestedNode(rootNode, GetNodeName(nameof(Account))));
                if (NodeExists(rootNode.NextSibling, GetNodeName(nameof(Closing))))
                {
                    Closing = new CreditCardClosingStatement(rootNode.NextSibling);
                }
            }
        }
        #endregion
    }
}
