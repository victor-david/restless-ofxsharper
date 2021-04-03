using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Account
{
    /// <summary>
    /// Represents the most primitive base class for information about an account, obtained via ACCTINFOTRNRQ.
    /// This class must be inherited.
    /// </summary>
    public abstract class AccountInfoPrimitive : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// When implemented in a derived class, gets the account associated with this account info.
        /// </summary>
        public abstract AccountBase Account
        {
            get;
        }

        /// <summary>
        /// Gets the service status. SVCSTATUS
        /// </summary>
        [NodeInfo("SVCSTATUS", Required = true)]
        public AccountInfoStatus Status
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
        internal AccountInfoPrimitive(XmlNode rootNode) 
        {
            // Null values here indicate programmer error.
            ValidateNull(rootNode, nameof(rootNode));
            Status = GetNodeValue(rootNode, nameof(Status)).ToAccountInfoStatus();
        }
        #endregion


        public T GetAccountAs<T>() where T:AccountBase
        {
            return Account as T;
        }

    }
}
