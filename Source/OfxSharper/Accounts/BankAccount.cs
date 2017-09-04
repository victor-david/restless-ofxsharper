using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents a bank account.
    /// </summary>
    public class BankAccount : AccountBase
    {
        #region Public properties
        /// <summary>
        /// Gets the account type
        /// </summary>
        public override AccountType AccountType => AccountType.Bank;

        /// <summary>
        /// ACCTTYPE. Type of account, see section 11.3.1.1
        /// </summary>
        [NodeInfo("ACCTTYPE")]
        public BankAccountType BankAccountType
        {
            get;
            private set;
        }

        /// <summary>
        /// BANKID. Routing and transit number, A-9 
        /// </summary>
        [NodeInfo("BANKID")]
        public string BankId
        {
            get;
            private set;
        }

        /// <summary>
        /// BRANCHID. Bank identifier for international banks, A-22
        /// </summary>
        [NodeInfo("BRANCHID")]
        public string BranchId
        {
            get;
            set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal BankAccount(XmlNode rootNode) : base(rootNode)
        {
            if (rootNode != null)
            {
                BankAccountType = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(BankAccountType)))).ToBankAccountType();
                BankId = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(BankId))));
                BranchId = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(BranchId))));
            }
        }
        #endregion
    }
}
