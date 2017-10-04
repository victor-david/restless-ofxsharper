using System;
using System.Collections.Generic;
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
        /// Gets the statements for this Ofx response, if applicable
        /// </summary>
        public StatementCollection Statements
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the payee list for this OfxResponse, if applicable.
        /// </summary>
        public PayeeCollection Payees
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the account information list for this Ofx response, of applicable.
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
        /// Initializes a new instance of the <see cref="OfxResponse"/> class.
        /// </summary>
        /// <param name="header">The header object</param>
        /// <param name="xmlDoc">The Xml document</param>
        internal OfxResponse(OfxHeader header, XmlDocument xmlDoc) : base (header, xmlDoc)
        {
            Statements = new StatementCollection(xmlDoc);
            Payees = new PayeeCollection(xmlDoc);
            AccountInfo = new AccountInfoCollection(xmlDoc);
        }
        #endregion

        /************************************************************************/

        #region Private methods
        #endregion
    }
}