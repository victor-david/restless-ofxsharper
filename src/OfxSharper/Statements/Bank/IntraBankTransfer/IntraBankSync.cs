using Restless.OfxSharper.Account;
using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents the intra bank sync response, INTRASYNCRS.
    /// </summary>
    public class IntraBankSync : OfxObjectBase
    {
        #region Internal fields
        internal const string NodeName = "INTRASYNCRS";
        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the token
        /// </summary>
        [NodeInfo("TOKEN", Required = true)]
        public string Token
        {
            get;
        }

        /// <summary>
        /// Gets the lost sync attributte.
        /// </summary>
        [NodeInfo("LOSTSYNC", Required = false)]
        public bool LostSync
        {
            get;
        }

        /// <summary>
        /// Gets the bank account
        /// </summary>
        [NodeInfo("BANKACCTFROM", Required = true)]
        public BankAccount Bank
        {
            get;
        }

        /// <summary>
        /// Gets the intar bank response object.
        /// </summary>
        [NodeInfo("INTRATRNRS", Required = true)]
        public IntraBankTransactionResponse Response
        {
            get;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="IntraBankSync"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal IntraBankSync(XmlNode rootNode) : base()
        {
            // Null values here indicate programmer error.
            ValidateNull(rootNode, nameof(rootNode));
            Token = GetNodeValue(rootNode, nameof(Token));
            LostSync = GetBooleanValue(rootNode, nameof(LostSync));
            Bank = new BankAccount(GetNestedNode(rootNode, GetNodeName(nameof(Bank))));
            Response = new IntraBankTransactionResponse(GetNestedNode(rootNode, GetNodeName(nameof(Response))));
        }
        #endregion
    }
}
