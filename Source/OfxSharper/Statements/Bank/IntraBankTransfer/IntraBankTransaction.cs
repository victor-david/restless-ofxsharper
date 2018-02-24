using Restless.OfxSharper.Core;
using System;
using System.Xml;

namespace Restless.OfxSharper.Statement
{
    public class IntraBankTransaction : OfxObjectBase
    {
        #region Internal fields
        internal const string NodeName = "INTRARS";
        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the default currency for this transaction.
        /// </summary>
        [NodeInfo("CURDEF", Required = true)]
        public string Currency
        {
            get;
        }

        /// <summary>
        /// Gets the server id for this transaction.
        /// </summary>
        [NodeInfo("SRVRTID", Required = true)]
        public string ServerId
        {
            get;
        }

        /// <summary>
        /// Gets the date/time the transaction is projected to post.
        /// Only one of this property and <see cref="DatePosted"/> may be non null.
        /// </summary>
        [NodeInfo("DTXFERPRJ", Required = false)]
        public DateTime? DateProjected
        {
            get;
        }

        /// <summary>
        /// Gets the date/time the transaction was posted.
        /// Only one of this property and <see cref="DateProjected"/> may be non null.
        /// </summary>
        [NodeInfo("DTPOSTED", Required = false)]
        public DateTime? DatePosted
        {
            get;
        }

        /// <summary>
        /// Gets the transfer info object.
        /// </summary>
        [NodeInfo("XFERINFO", Required = true)]
        public TransferInfo XferInfo
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
        internal IntraBankTransaction(XmlNode rootNode)
        {
            // Null values here indicate programmer error.
            ValidateNull(rootNode, nameof(rootNode));
            Currency = GetNodeValue(rootNode, nameof(Currency));
            ServerId = GetNodeValue(rootNode, nameof(ServerId));
            DateProjected = GetNullableDateTimeValue(rootNode, nameof(DateProjected));
            DatePosted = GetNullableDateTimeValue(rootNode, nameof(DatePosted));
            XferInfo = new TransferInfo(GetNestedNode(rootNode, GetNodeName(nameof(XferInfo))));
        }
        #endregion
    }
}
