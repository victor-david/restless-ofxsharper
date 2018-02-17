using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents a container that holds information such as account information and payee lists
    /// </summary>
    public class InformationMessageSet : OfxMessageSetBase2
    {
        #region Private
        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the message set name for the bill pay message set. Used for <see cref="Payees"/>.
        /// </summary>
        protected override string MessageSetName1 => $"BILLPAYMSGSRSV{MessageSetVersion}";

        /// <summary>
        /// Gets the message set name for the signup message set. Used for <see cref="AccountInfo"/>.
        /// </summary>
        /// 
        protected override string MessageSetName2 => $"SIGNUPMSGSRSV{MessageSetVersion}";

        /// <summary>
        /// Gets the payee list for this OfxResponse, if applicable.
        /// </summary>
        public PayeeCollection Payees
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the account information list for this Ofx response, if applicable.
        /// </summary>
        public AccountInfoCollection AccountInfo
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="InformationMessageSet"/> class.
        /// </summary>
        /// <param name="xmlDoc">The xml document</param>
        /// <param name="messageSetVersion">The message set version to use.</param>
        internal InformationMessageSet(XmlDocument xmlDoc, int messageSetVersion) : base(messageSetVersion)
        {
            Payees = new PayeeCollection(GetNestedNode(xmlDoc.FirstChild, MessageSetName1));
            AccountInfo = new AccountInfoCollection(GetNestedNode(xmlDoc.FirstChild, MessageSetName2));
        }
        #endregion
    }
}
