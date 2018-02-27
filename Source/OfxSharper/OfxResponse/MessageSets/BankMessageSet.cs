using Restless.OfxSharper.Core;
using Restless.OfxSharper.Statement;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents the top level message set response for a bank. BANKMSGSRSVx and CREDITCARDMSGSRSVx
    /// </summary>
    public class BankMessageSet : OfxMessageSetBase2
    {
        #region Private
        #endregion

        /************************************************************************/

        #region Protected properties
        /// <summary>
        /// Gets the bank message set name.
        /// </summary>
        protected override string MessageSetName1 => $"BANKMSGSRSV{MessageSetVersion}";

        /// <summary>
        /// Gets the credit card message set name.
        /// </summary>
        protected override string MessageSetName2 => $"CREDITCARDMSGSRSV{MessageSetVersion}";
        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the bank statements (checking, saving, credit card) for this Ofx response.
        /// </summary>
        public BankStatementCollection Statements
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the collection of intra bank transfer responses.
        /// </summary>
        public IntraBankTransactionResponseCollection IntraBankTransfers
        {
            get;
        }

        /// <summary>
        /// Gets the collection of intra bank synchronization responses.
        /// </summary>
        public IntraBankSyncCollection IntraBankSyncs
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="BankMessageSet"/> class.
        /// </summary>
        /// <param name="xmlDoc">The xml document</param>
        /// <param name="messageSetVersion">The message set version to use.</param>
        internal BankMessageSet(XmlDocument xmlDoc, int messageSetVersion) : base(messageSetVersion)
        {
            Statements = new BankStatementCollection(GetNestedNode(xmlDoc.FirstChild, MessageSetName1), GetNestedNode(xmlDoc.FirstChild, MessageSetName2));
            IntraBankTransfers = new IntraBankTransactionResponseCollection(GetNestedNode(xmlDoc.FirstChild, MessageSetName1));
            IntraBankSyncs = new IntraBankSyncCollection(GetNestedNode(xmlDoc.FirstChild, MessageSetName1));
        }
        #endregion
    }
}
