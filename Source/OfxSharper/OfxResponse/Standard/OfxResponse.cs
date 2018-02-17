using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents an Ofx response
    /// </summary>
    public class OfxResponse : OfxResponseBase
    {
        #region Public properties
        /// <summary>
        /// Gets the top level bank container object which holds bank statements etc.
        /// </summary>
        public BankMessageSet Bank
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the top level investment container object which holds investment statements and investment security information.
        /// </summary>
        public InvestmentMessageSet Investment
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the top level information container which holds account info and payee info if requested.
        /// </summary>
        public InformationMessageSet Information
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxResponse"/> class.
        /// </summary>
        /// <param name="header">The header object</param>
        /// <param name="xmlDoc">The Xml document</param>
        /// <param name="messageSetVersion">The message set version to use.</param>
        internal OfxResponse(OfxHeader header, XmlDocument xmlDoc, int messageSetVersion) : base (header, xmlDoc)
        {
            Bank = new BankMessageSet(xmlDoc, messageSetVersion);
            Investment = new InvestmentMessageSet(xmlDoc, messageSetVersion);
            Information = new InformationMessageSet(xmlDoc, messageSetVersion);
        }
        #endregion

        /************************************************************************/

        #region Private methods
        #endregion
    }
}