using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents an intra bank transfer response, INTRATRNRS.
    /// </summary>
    public class IntraBankTransactionResponse : TransactionMessageBase
    {
        #region Internal fields
        internal const string NodeName = "INTRATRNRS";
        #endregion

        #region Public properties
        /// <summary>
        /// Gets the collection of intra bank transaction objects.
        /// </summary>
        public IntraBankTransactionCollection Transactions
        {
            get;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="IntraBankTransactionResponse"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal IntraBankTransactionResponse(XmlNode rootNode) : base(rootNode)
        {
            XmlNode transIdNode = GetNestedNode(rootNode, GetNodeName(nameof(TransactionWrapperUniqueId)));
            Transactions = new IntraBankTransactionCollection(transIdNode);
        }
        #endregion
    }
}
