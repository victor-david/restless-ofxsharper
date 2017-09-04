using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents the base class for an account. This class must be inherited.
    /// </summary>
    public abstract class AccountBase : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// When implemented by a derived class, gets the type of account.
        /// </summary>
        public abstract AccountType AccountType
        {
            get;
        }

        /// <summary>
        /// ACCTID. Account number, A-22
        /// </summary>
        [NodeInfo("ACCTID")]
        public string AccountId
        {
            get;
            private set;
        }

        /// <summary>
        /// ACCTKEY. Checksum for international banks, A-22
        /// </summary>
        [NodeInfo("ACCTKEY")]
        public string AccountKey
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBase"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        protected AccountBase(XmlNode rootNode)
        {
            if (rootNode != null)
            {
                AccountId = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(AccountId))));
                AccountKey = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(AccountKey))));
            }
        }
        #endregion
    }
}
