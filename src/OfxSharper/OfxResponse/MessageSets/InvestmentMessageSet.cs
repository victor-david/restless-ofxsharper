using Restless.OfxSharper.Core;
using Restless.OfxSharper.Statement;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents the top level message set response for an investment. INVSTMTMSGSRSVx and SECLISTMSGSRSVx
    /// </summary>
    public class InvestmentMessageSet : OfxMessageSetBase2
    {
        #region Private
        #endregion

        /************************************************************************/

        #region Protected properties
        /// <summary>
        /// Gets the message set name. Used for <see cref="Statements"/>
        /// </summary>
        protected override string MessageSetName1 => $"INVSTMTMSGSRSV{MessageSetVersion}";

        /// <summary>
        /// Gets the message set name. Used for <see cref="Securities"/>.
        /// </summary>
        protected override string MessageSetName2 => $"SECLISTMSGSRSV{MessageSetVersion}";

        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the list of statements.
        /// </summary>
        public InvestmentStatementCollection Statements
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the list of security information.
        /// </summary>
        public SecurityInfoCollection Securities
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="InvestmentMessageSet"/> class.
        /// </summary>
        /// <param name="xmlDoc">The xml document</param>
        /// <param name="messageSetVersion">The message set version to use.</param>
        internal InvestmentMessageSet(XmlDocument xmlDoc, int messageSetVersion) : base(messageSetVersion)
        {
            Statements = new InvestmentStatementCollection(GetNestedNode(xmlDoc.FirstChild, MessageSetName1));
            Securities = new SecurityInfoCollection(GetNestedNode(xmlDoc.FirstChild, MessageSetName2));
        }
        #endregion
    }
}
