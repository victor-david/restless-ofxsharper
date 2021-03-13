using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Account
{
    /// <summary>
    /// Represents the base class for a bank (checking, savings, credit card) account. This class must be inherited.
    /// </summary>
    public abstract class BankAccountBase : AccountBase
    {
        #region Public properties
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
        /// Initializes a new instance of the <see cref="BankAccountBase"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        protected BankAccountBase(XmlNode rootNode) : base(rootNode)
        {
            if (rootNode != null)
            {
                AccountKey = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(AccountKey))));
            }
        }
        #endregion
    }
}
