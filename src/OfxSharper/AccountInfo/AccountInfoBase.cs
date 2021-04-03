using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Account
{
    /// <summary>
    /// Represents the base class for information about an account, obtained via ACCTINFOTRNRQ.
    /// This class must be inherited.
    /// </summary>
    public abstract class AccountInfoBase : AccountInfoPrimitive
    {
        #region Public properties
        /// <summary>
        /// Gets the account description. DESC.
        /// A server uses the DESC field to convey the FI’s preferred name for the account, such as "PowerChecking." 
        /// </summary>
        [NodeInfo("DESC", Required = false)]
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the phone number for the account. PHONE
        /// </summary>
        [NodeInfo("PHONE", Required = false)]
        public string Phone
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountInfoBase"/> class.
        /// </summary>
        internal AccountInfoBase(XmlNode rootNode) : base (rootNode)
        {
            // rootNode cannot be null. Base class constructor throws if so.
            Description = GetNodeValue(rootNode, nameof(Description));
            Phone = GetNodeValue(rootNode, nameof(Phone));
        }
        #endregion
    }
}
